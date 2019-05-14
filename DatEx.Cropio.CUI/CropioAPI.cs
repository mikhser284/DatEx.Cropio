using DatEx.Cropio.BaseAPI;
using System;
using System.Collections.Generic;

namespace DatEx.Cropio.CUI
{
    public class CropioApi : CropioBaseAPi
    {
        private String _agentLogin;
        private String _agentPassword;

        private String _userApiToken = String.Empty;
        private String UserApiToken { get { return _userApiToken; } }
        private String UserApiToken_Update()
        {
            AuthorizationResponse authorizationResponse = _Login(_agentLogin, _agentPassword);
            _userApiToken = authorizationResponse.UserApiToken;
            return _userApiToken;
        }
                
        private TimeSpan? _cropioServerTimeDelta = null;
        public TimeSpan CropioServerTimeDelta { get { return _cropioServerTimeDelta ?? CropioServerTimeDelta_Update(); } }
        public TimeSpan CropioServerTimeDelta_Update()
        {
            try
            {
                return _GetServerDeltaTime(UserApiToken);
            }
            catch(CropioAuthorizationException)
            {
                UserApiToken_Update();
                return _GetServerDeltaTime(UserApiToken);
            }
        }

        public CropioApi(String baseAddress, String login, String password) : base(baseAddress)
        {
            _agentLogin = login;
            _agentPassword = password;
        }
        
        public MassResponse<Int32> GetObjectsIds<T>() where T : ICropioObject
        {
            try
            {
                return _GetObjectsIds<T>(UserApiToken);
            }
            catch(CropioAuthorizationException)
            {
                UserApiToken_Update();
                return _GetObjectsIds<T>(UserApiToken);
            }
        }

        public MassResponse<T> GetObjects<T>(IEnumerable<Int32> objIds) where T : ICropioObject
        {
            try
            {
                return _GetObjects<T>(UserApiToken, objIds);
            }
            catch(CropioAuthorizationException)
            {
                UserApiToken_Update();
                return _GetObjects<T>(UserApiToken, objIds);
            }
        }

        public MassResponse<T> GetObjects<T>(Int32 limit, Int32 fromId = 0) where T : ICropioObject
        {
            try
            {
                return _GetObjects<T>(UserApiToken, limit, fromId);
            }
            catch(CropioAuthorizationException)
            {
                UserApiToken_Update();
                return _GetObjects<T>(UserApiToken, limit, fromId);
            }            
        }

        public Response<T> GetObject<T>(Int32 objId) where T : ICropioObject
        {
            try
            {
                return _GetObject<T>(UserApiToken, objId);
            }
            catch(CropioAuthorizationException)
            {
                UserApiToken_Update();
                return _GetObject<T>(UserApiToken, objId);
            }              
        }

        public MassResponse_Changes GetChangedObjectsIds<T>(DateTime? fromTime = null) where T : ICropioObject
        {
            DateTime time = fromTime ?? new DateTime();
            try
            {
                return _GetChangedObjectsIds<T>(UserApiToken, time, CropioServerTimeDelta);
            }
            catch(CropioAuthorizationException)
            {
                UserApiToken_Update();
                return _GetChangedObjectsIds<T>(UserApiToken, time, CropioServerTimeDelta);
            }            
        }

        public MassResponse_ChangedObjects<T> GetChangedObjects<T>(Int32 limit, DateTime fromTime) where T : ICropioObject
        {
            try
            {
                return _GetChangedObjects<T>(UserApiToken, limit, fromTime, CropioServerTimeDelta);
            }
            catch(CropioAuthorizationException)
            {
                UserApiToken_Update();
                return _GetChangedObjects<T>(UserApiToken, limit, fromTime, CropioServerTimeDelta);
            }            
        }

        public Response<T> CreateObject<T>(T newObj) where T : ICropioObject
        {
            try
            {
                return _CreateObject<T>(UserApiToken, newObj);
            }
            catch(CropioAuthorizationException)
            {
                UserApiToken_Update();
                return _CreateObject<T>(UserApiToken, newObj);
            }
        }

        public Response<T> UpdateObject<T>(T existingObj) where T : ICropioObject
        {
            try
            {
                return _UpdateObject<T>(UserApiToken, existingObj);
            }
            catch(CropioAuthorizationException)
            {
                UserApiToken_Update();
                return _UpdateObject<T>(UserApiToken, existingObj);
            }
        }

        public CropioResponse DeleteObject<T>(Int32 objId) where T : ICropioObject
        {
            try
            {
                return _DeleteObject<T>(UserApiToken, objId);
            }
            catch(CropioAuthorizationException)
            {
                UserApiToken_Update();
                return _DeleteObject<T>(UserApiToken, objId);
            }
        }

        public MassResponse<CO_Document> ObjRelatedDocument<T>(Int32 objId) where T : ICropioDocumentableObject
        {
            try
            {
                return _GetRelatedDocument<T>(UserApiToken, objId);
            }
            catch(CropioAuthorizationException)
            {
                UserApiToken_Update();
                return _GetRelatedDocument<T>(UserApiToken, objId);
            }
        }

        public Byte[] DownloadDocumentFile(Int32 documentId)
        {
            try
            {
                return _DownloadDocumentFile(UserApiToken, documentId);
            }
            catch(CropioAuthorizationException)
            {
                UserApiToken_Update();
                return _DownloadDocumentFile(UserApiToken, documentId);
            }
        }

        public void SaveJsonObjectsToFile<T>()  where T : ICropioObject
        {
            try
            {
                _SaveJsonObjectsToFile<T>(UserApiToken);
            }
            catch(CropioAuthorizationException)
            {
                UserApiToken_Update();
                _SaveJsonObjectsToFile<T>(UserApiToken);
            }
        }
    }
}
