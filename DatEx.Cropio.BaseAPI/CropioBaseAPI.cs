using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    public class CropioBaseAPi
    {
        public static string DefaultAddress_ProductiveServer { get { return "https://cropio.com/api/v3/"; } }
        public static string DefaultAddress_DebuggingProxy { get { return "https://private-anon-01e2570f0f-cropioapiv3.apiary-proxy.com/api/v3/"; } }
        public static string DefaultAddress_MockServer { get { return "https://private-anon-01e2570f0f-cropioapiv3.apiary-mock.com/api/v3/"; } }

        readonly Uri BaseAddress;
        
        protected CropioBaseAPi(String baseAddress)
        {
            if(String.IsNullOrEmpty(baseAddress)) throw new ArgumentNullException("baseAddress");
            BaseAddress = new Uri(baseAddress);
        }
        
        /// <summary> Получить разницу во времени с сервером Cropio </summary>
        protected TimeSpan _GetServerDeltaTime(String userApiToken)
        {
            if(String.IsNullOrEmpty(userApiToken)) throw new CropioAuthorizationException();
            DateTime time = DateTime.Now;
            String requestAddress = String.Format(@"{0}/changes_ids?from_time={1}", CropioDataModel.Name<CO_AlertType>(), time);
            TimeSpan timeDelta;
            using(HttpClient httpClient = HttpClientHelper.ConstructHttpClient(userApiToken, BaseAddress))
            {
                using(HttpResponseMessage response = httpClient.GetAsync(requestAddress).Result)
                {
                    String responseData = response.Content.ReadAsStringAsync().Result.RemoveBackSlashFromJson();
                    DateTime time2 =  (JsonConvert.DeserializeObject<MassResponse_Changes>(responseData)).Meta.Request.FromTime;
                    timeDelta = time2 - time;
                }
            }
            return timeDelta;
        }
        
        /// <summary> Получить токен аутентификации </summary>
        /// <param name="login"> Електронная почта </param>
        /// <param name="password"> Пароль </param>
        protected AuthorizationResponse _Login(String login, String password)
        {
            AuthorizationResponse serverUserApiToken;
            String requestContent = String.Format(@"{{ ""user_login"": {{ ""email"": ""{0}"", ""password"": ""{1}"" }}}}", login, password);
            using(HttpClient httpClient = new HttpClient { BaseAddress = this.BaseAddress })
            {
                using(StringContent content = new StringContent(requestContent, Encoding.UTF8, "application/json"))
                {
                    using(HttpResponseMessage response = httpClient.PostAsync("sign_in", content).Result)
                    {
                        String responseData = response.Content.ReadAsStringAsync().Result.RemoveBackSlashFromJson();
#if DEBUG
                        responseData = JToken.Parse(responseData).ToString(Formatting.Indented);
#endif
                        serverUserApiToken = JsonConvert.DeserializeObject<AuthorizationResponse>(responseData);
                    }
                }
            }
            if(serverUserApiToken.Result_IsSuccess != true)
            {
                throw new CropioAuthorizationException(String.Format("Не удачная попытка авторизации: {0}", serverUserApiToken.Result_Message));
            }
            return serverUserApiToken;
        }
        
        /// <summary> Get list of GetObjectsIds for all objects </summary>
        protected MassResponse<Int32> _GetObjectsIds<T>(String userApiToken) where T : ICropioObject
        {
            String requestAddress = String.Format(@"{0}/ids", CropioDataModel.Name<T>());
            MassResponse<Int32> identifiersSet;
            using(HttpClient httpClient = HttpClientHelper.ConstructHttpClient(userApiToken, BaseAddress))
            {
                using(HttpResponseMessage response = httpClient.GetAsync(requestAddress).Result)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new CropioAuthorizationException("Авторизация не выполнена");
                    String responseData = response.Content.ReadAsStringAsync().Result.RemoveBackSlashFromJson();
#if DEBUG
                    responseData = JToken.Parse(responseData).ToString(Formatting.Indented);
#endif
                    identifiersSet = JsonConvert.DeserializeObject<MassResponse<Int32>>(responseData);
                    identifiersSet.CropioResponse = new CropioResponse(response);
                }
            }
            return identifiersSet;
        }
        
        /// <summary> Get list of GetObjectsIds for all objects </summary>
        protected MassResponse<CO_Document> _GetRelatedDocument<T>(String userApiToken, Int32 objId) where T : ICropioDocumentableObject
        {
            String requestAddress = String.Format(@"protected_documents?documentable_type={0}&documentable_id={1}", CropioDataModel.DocumentableObjectTypeName<T>(), objId);
            MassResponse<CO_Document> result;
            using(HttpClient httpClient = HttpClientHelper.ConstructHttpClient(userApiToken, BaseAddress))
            {
                using(HttpResponseMessage response = httpClient.GetAsync(requestAddress).Result)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new CropioAuthorizationException("Авторизация не выполнена");
                    String responseData = response.Content.ReadAsStringAsync().Result.RemoveBackSlashFromJson();
#if DEBUG
                    responseData = JToken.Parse(responseData).ToString(Formatting.Indented);
#endif
                    result = JsonConvert.DeserializeObject<MassResponse<CO_Document>>(responseData);
                    result.CropioResponse = new CropioResponse(response);
                }
            }
            return result;
        }

        protected Byte[] _DownloadDocumentFile(String userApiToken, Int32 documentId)
        {
            String requestAddress = String.Format(@"download_protected_documents/{0}", documentId);
            Byte[] fileContent = null;
            using(HttpClient httpClient = HttpClientHelper.ConstructHttpClient(userApiToken, BaseAddress))
            {
                using(HttpResponseMessage response = httpClient.GetAsync(requestAddress).Result)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new CropioAuthorizationException("Авторизация не выполнена");
                    if(response.IsSuccessStatusCode)
                    {
                        fileContent = response.Content.ReadAsByteArrayAsync().Result;
                    }                    
                }
            }
            return fileContent;
        }

        /// <summary> Get the big number of objects by posting the list of ids </summary>
        protected MassResponse<T> _GetObjects<T>(String userApiToken, IEnumerable<Int32> objIds) where T : ICropioObject
        {
            String requestAddress = String.Format(CropioDataModel.Name<T>() + "/mass_request");
            String requestContent = String.Format(@"{{ ""data"": [{0}] }}", String.Join(", ", objIds));
            MassResponse<T> obj;
            using(HttpClient httpClient = HttpClientHelper.ConstructHttpClient(userApiToken, BaseAddress))
            {
                using (StringContent content = new StringContent(requestContent, Encoding.UTF8, "application/json"))
                {
                    using(HttpResponseMessage response = httpClient.PostAsync(requestAddress, content).Result)
                    {
                        if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new CropioAuthorizationException("Авторизация не выполнена");
                        String responseJson = response.Content.ReadAsStringAsync().Result.RemoveBackSlashFromJson();
#if DEBUG
                        responseJson = JToken.Parse(responseJson).ToString(Formatting.Indented);
#endif
                        obj = JsonConvert.DeserializeObject<MassResponse<T>>(responseJson);
                        obj.CropioResponse = new CropioResponse(response);
                    }
                }
            }
            return obj;
        }
        
        /// <summary> Get the big number of objects by posting the list of ids </summary>
        protected void _SaveJsonObjectsToFile<T>(String userApiToken) where T : ICropioObject
        {
            String directoryPath = "../../../__Cropio DB objects (JSON)";
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
            
            String filename = String.Format("{0}//{1}.json", directoryPath, CropioDataModel.Name<T>());
            MassResponse<Int32> objIds = _GetObjectsIds<T>(userApiToken);
            FileInfo file = new FileInfo(filename);
            if(file.Exists) file.Delete();
            //
            using (StreamWriter stream = file.CreateText())
            {
                foreach(IEnumerable<Int32> idsPage in objIds.Data.Paginate(200))
                {
                    String requestAddress = String.Format(CropioDataModel.Name<T>() + "/mass_request");
                    String requestContent = String.Format(@"{{ ""data"": [{0}] }}", String.Join(", ", idsPage));

                    using(HttpClient httpClient = HttpClientHelper.ConstructHttpClient(userApiToken, BaseAddress))
                    {
                        using(StringContent content = new StringContent(requestContent, Encoding.UTF8, "application/json"))
                        {
                            using(HttpResponseMessage response = httpClient.PostAsync(requestAddress, content).Result)
                            {
                                if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new CropioAuthorizationException("Авторизация не выполнена");
                                String responseJson = response.Content.ReadAsStringAsync().Result.RemoveBackSlashFromJson();
                                responseJson = JToken.Parse(responseJson).ToString(Formatting.Indented);
                                stream.Write(responseJson);
                            }
                        }
                    }
                }
            }   
            Console.WriteLine("Получение объектов {0} завершено", CropioDataModel.Name<T>());
        }

        /// <summary> Get list of objects </summary>
        protected MassResponse<T> _GetObjects<T>(String userApiToken, Int32 limit, Int32 fromId = 0) where T : ICropioObject
        {
            String requestAddress = String.Format("{0}?limit={1},from_id={2}", CropioDataModel.Name<T>(), limit, fromId);
            MassResponse<T> obj;
            using(HttpClient httpClient = HttpClientHelper.ConstructHttpClient(userApiToken, BaseAddress))
            {   
                using(HttpResponseMessage response = httpClient.GetAsync(requestAddress).Result)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new CropioAuthorizationException("Авторизация не выполнена");
                    String responseJson = response.Content.ReadAsStringAsync().Result.RemoveBackSlashFromJson();
                    obj = JsonConvert.DeserializeObject<MassResponse<T>>(responseJson);
                    obj.CropioResponse = new CropioResponse(response);
                }
            }
            return obj;
        }
        
        /// <summary> Get one object by id </summary>
        protected Response<T> _GetObject<T>(String userApiToken, Int32 objId) where T : ICropioObject
        {
            String requestAddress = String.Format(@"{0}/{1}", CropioDataModel.Name<T>(), objId);
            Response<T> obj;
            using(HttpClient httpClient = HttpClientHelper.ConstructHttpClient(userApiToken, BaseAddress))
            {
                using(HttpResponseMessage response = httpClient.GetAsync(requestAddress).Result)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new CropioAuthorizationException("Авторизация не выполнена");
                    String responseJson = response.Content.ReadAsStringAsync().Result.RemoveBackSlashFromJson();
#if DEBUG
                    responseJson = JToken.Parse(responseJson).ToString(Formatting.Indented);
#endif
                    obj = JsonConvert.DeserializeObject<Response<T>>(responseJson);
                    obj.CropioResponse = new CropioResponse(response);
                }
            }
            return obj;
        }
        
        /// <summary> Get list of GetObjectsIds for objects changed in specified period </summary>
        /// <remarks> Параметр cropioServerTimeDelta можно получить используя функцию GetServerDeltaTime </remarks>
        protected MassResponse_Changes _GetChangedObjectsIds<T>(String userApiToken, DateTime fromTime, TimeSpan cropioServerTimeDelta) where T : ICropioObject
        {
            DateTime timeFrom;
            try { timeFrom = fromTime - cropioServerTimeDelta; }
            catch(Exception ex) { timeFrom = new DateTime(); }
            String requestAddress = String.Format(@"{0}/changes_ids?from_time={1}", CropioDataModel.Name<T>(), timeFrom);            
            MassResponse_Changes identifiersSet;
            using(HttpClient httpClient = HttpClientHelper.ConstructHttpClient(userApiToken, BaseAddress))
            {
                using(HttpResponseMessage response = httpClient.GetAsync(requestAddress).Result)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new CropioAuthorizationException("Авторизация не выполнена");
                    String responseData = response.Content.ReadAsStringAsync().Result.RemoveBackSlashFromJson();
#if DEBUG
                    responseData = JToken.Parse(responseData).ToString(Formatting.Indented);                    
#endif
                    identifiersSet = JsonConvert.DeserializeObject<MassResponse_Changes>(responseData);
                    identifiersSet.CropioResponse = new CropioResponse(response);
                }
            }
            
            return identifiersSet;
        }
        
        /// <summary> Get objects changed in specified period </summary>
        /// <remarks> Параметр cropioServerTimeDelta можно получить используя функцию GetServerDeltaTime </remarks>
        protected MassResponse_ChangedObjects<T> _GetChangedObjects<T>(String userApiToken, Int32 limit, DateTime fromTime, TimeSpan cropioServerTimeDelta) where T : ICropioObject
        {
            DateTime timeFrom = fromTime + cropioServerTimeDelta;
            String requestAddress = String.Format(@"{0}/changes?{1}from_time={2}", CropioDataModel.Name<T>(), limit, timeFrom);
            MassResponse_ChangedObjects<T> identifiersSet;
            using(HttpClient httpClient = HttpClientHelper.ConstructHttpClient(userApiToken, BaseAddress))
            {
                using(HttpResponseMessage response = httpClient.GetAsync(requestAddress).Result)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new CropioAuthorizationException("Авторизация не выполнена");
                    String responseData = response.Content.ReadAsStringAsync().Result.RemoveBackSlashFromJson();
#if DEBUG
                    responseData = JToken.Parse(responseData).ToString(Formatting.Indented);
#endif
                    identifiersSet = JsonConvert.DeserializeObject<MassResponse_ChangedObjects<T>>(responseData);
                    identifiersSet.CropioResponse = new CropioResponse(response);
                }
            }
            
            return identifiersSet;
        }

        // ▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬

        /// <summary> CreateNewObject </summary>
        protected Response<T> _CreateObject<T>(String userApiToken, T newObj) where T : ICropioObject
        {
            Response<T> asdf = new Response<T> { Data = newObj };

            string json = JsonConvert.SerializeObject(asdf, Formatting.Indented);

            String requestAddress = CropioDataModel.Name<T>();
            Response<T> obj;
            using(HttpClient httpClient = HttpClientHelper.ConstructHttpClient(userApiToken, BaseAddress))
            {
                using (StringContent content = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    using(HttpResponseMessage response = httpClient.PostAsync(requestAddress, content).Result)
                    {
                        if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new CropioAuthorizationException("Авторизация не выполнена");
                        String responseData = response.Content.ReadAsStringAsync().Result.RemoveBackSlashFromJson();
#if DEBUG
                        responseData = JToken.Parse(responseData).ToString(Formatting.Indented);
#endif
                        obj = JsonConvert.DeserializeObject<Response<T>>(responseData);
                        obj.CropioResponse = new CropioResponse(response);
                    }
                }
            }
            return obj;
        }
        
        /// <summary> Update object by ID </summary>
        protected Response<T> _UpdateObject<T>(String userApiToken, T existingObj) where T : ICropioObject
        {
            Response<T> asdf = new Response<T> { Data = existingObj };

            string json = JsonConvert.SerializeObject(asdf, Formatting.Indented);

            String requestAddress = String.Format(@"{0}/{1}", CropioDataModel.Name<T>(), existingObj.Id);
            Response<T> obj;
            using(HttpClient httpClient = HttpClientHelper.ConstructHttpClient(userApiToken, BaseAddress))
            {
                using (StringContent content = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    using(HttpResponseMessage response = httpClient.PutAsync(requestAddress, content).Result)
                    {
                        if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new CropioAuthorizationException("Авторизация не выполнена");
                        String responseData = response.Content.ReadAsStringAsync().Result.RemoveBackSlashFromJson();
#if DEBUG
                        responseData = JToken.Parse(responseData).ToString(Formatting.Indented);
#endif
                        obj = JsonConvert.DeserializeObject<Response<T>>(responseData);
                        obj.CropioResponse = new CropioResponse(response);
                    }
                }
            }
            return obj;
        }
        
        /// <summary> Delete object by id </summary>
        protected CropioResponse _DeleteObject<T>(String userApiToken, Int32 objId) where T : ICropioObject
        {
            String requestAddress = String.Format(@"{0}/{1}", CropioDataModel.Name<T>(), objId);
            CropioResponse cropioResponse;
            using(HttpClient httpClient = HttpClientHelper.ConstructHttpClient(userApiToken, BaseAddress))
            {   
                using(HttpResponseMessage response = httpClient.DeleteAsync(requestAddress).Result)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new CropioAuthorizationException("Авторизация не выполнена");
                    cropioResponse = new CropioResponse(response);
                }
            }
            return cropioResponse;
        }
    }
}
