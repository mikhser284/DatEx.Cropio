using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatEx.Cropio.BaseAPI;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DatEx.Cropio.CUI
{
    public static class RunMultipleAlertsFromOutside
    {
        public const String DirPath_LocalDataStorage = @"..\..\..\..\!Data\Cropio";
        public static void Main(CropioApi cropio)
        {
            RunAllertsTest(cropio);

            var users = GetUsersWithExternalID().OrderBy(x => x.Status);
            
            foreach(var u in users)
            {
                List<View_Field> userAllowedFields = GetUserRelatedFields(cropio, new Guid(u.Id_External))
                    .OrderBy(x => x.FieldsGroupName).ThenBy(x => x.CropName).ThenBy(x => x.HistoryItemVariety).ThenBy(x => x.Name).ToList();
                foreach(var usr in users)
                {
                    Boolean isCurrentUser = usr.Id == u.Id;
                    var background = Console.BackgroundColor;
                    if(isCurrentUser) Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($" {(isCurrentUser ? "■" : " ")} | {usr.UserName, -50} | {usr.Position, -50} | {usr.Status}");
                    Console.BackgroundColor = background;
                }
                Console.WriteLine("————————————————————————————————————————————————————————————————————————————————");
                Console.WriteLine($"User available fields: {userAllowedFields.Count}");
                Console.WriteLine("————————————————————————————————————————————————————————————————————————————————");
                Console.ReadLine();
                foreach(var f in userAllowedFields) Console.WriteLine($"{f}");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public static List<CropioResponse> AllertsCreate(CropioApi cropio, List<Int32> fieldsIds, Int32 alertTypeId, String alertDescription, DateTime eventStartTime)
        {
            List<CropioResponse> cropioResponses = new List<CropioResponse>();
            foreach(var fieldId in fieldsIds)
            {
                CO_Alert alert = new CO_Alert
                {
                    Id_AlertableObject = fieldId,
                    Description = alertDescription,
                    Id_AlertType = alertTypeId,
                    EventStartTime = eventStartTime,
                    Status = CE_StatusOfAllert.Open,
                    AlertableObjectType = CE_AlertableObjectType.Field,
                    CreatedAt = DateTime.Now,
                };
                cropioResponses.Add(cropio.CreateObject(alert).CropioResponse);
            }
            return cropioResponses;
        }

        public static List<CropioResponse> AllertsAssignResponsible(CropioApi cropio, List<Int32> alertsIds, Int32 responsibleId, String remark, DateTime timeStamp)
        {
            List<CropioResponse> cropioResponses = new List<CropioResponse>();
            //TODO
            return cropioResponses;
        }

        public static List<CropioResponse> AlertsAddRemark(CropioApi cropio, List<Int32> alertsIds, String remark, DateTime timeStamp)
        {
            List<CropioResponse> cropioResponses = new List<CropioResponse>();
            //TODO
            return cropioResponses;
        }

        public static List<CropioResponse> AlertsClose(CropioApi cropio, List<Int32> alertsIds, String remark, DateTime timeStamp)
        {
            List<CropioResponse> cropioResponses = new List<CropioResponse>();
            //TODO
            return cropioResponses;
        }

        public static void RunAllertsTest(CropioApi cropio)
        {
            List<Int32> fieldsIds = new List<Int32> { 198, 200, 202, 203, 205, 206, 321, 199, 201, 196, 197, 224, 204, 207, 322, 210 };
            var result = AllertsCreate(cropio, fieldsIds, 6, "[#Test 5] This allert belong to allerts set #5 which was runned from 3rd party software", DateTime.Now);
            foreach(var res in result)
            {
                Console.WriteLine(res.IsSuccess);
            }
        }

        private static List<CO_User> GetUsersWithExternalID()
        {
            Guid userGuid = new Guid();
            return LoadDataFromJsonFile<CO_User>().Where(x => !String.IsNullOrEmpty(x.Id_External) && Guid.TryParse(x.Id_External, out userGuid)).ToList();
        }

        private static List<View_Field> GetUserRelatedFields(CropioApi cropio, Guid userExternalId)
        {
            SyncroniseData(cropio);
            var user = LoadDataFromJsonFile<CO_User>().FirstOrDefault(x => String.Equals(x.Id_External, userExternalId.ToString(), StringComparison.InvariantCultureIgnoreCase));
            if(user == null) throw new InvalidOperationException(String.Format("Пользователь с внешним идентификатором \"{0}\" не найден", userExternalId));
            if(user.Status == CE_UserStatus.NoAccess) return new List<View_Field>();
            List<View_Field> userAllowedFields = GetActualFields(cropio);
            if(user.Status != CE_UserStatus.User) return userAllowedFields;            
            // return fields allowed for current user
            List<CO_UserRoleAssignment> rolesAssignment = LoadDataFromJsonFile<CO_UserRoleAssignment>()
                .Where(x => x.Id_User == user.Id).ToList();
            List<CO_UserRole> userRoles = LoadDataFromJsonFile<CO_UserRole>()
                .Intersect(rolesAssignment, (a, b) => a.Id == b.Id_UserRole).ToList();
            List<CO_UserRolePermission> userRolePermissions = LoadDataFromJsonFile<CO_UserRolePermission>()
                .Where(x => x.SubjectType == CE_UserRolePermissionSubjectType.FieldGroup && (x.AccessLevel != CE_AccessLevel.NoAccess))
                .Intersect(userRoles, (a, b) => a.Id_UserRole == b.Id).ToList();
            userAllowedFields = userAllowedFields.Intersect(userRolePermissions, (a, b) => a.Id_FieldGroup == b.Id_Subject).ToList();
            return userAllowedFields;
        }

        private static List<View_Field> GetActualFields(CropioApi cropio)
        {
            var historyInventoryItems = LoadDataFromJsonFile<CO_History_InventoryItem>()
                .Where(x => x.HistoryableType == CE_HistoryableType.Field)
                .GroupBy(x => x.Id_Historyable)
                .Select(g => g.OrderByDescending(i => i.RecordComesIntoEffectAt).First())
                .Where(x => x.IsAvailable && !x.IsHidden)
                .ToList();
            List<View_Field> fields = LoadDataFromJsonFile<CO_Field>()
                .Intersect(historyInventoryItems, (a, b) => a.Id == b.Id_Historyable)
                .Join(LoadDataFromJsonFile<CO_FieldGroup>(), o => o.Id_FieldGroup, i => i.Id, (o, i) => new
                {   
                    o.AdministrativeAreaName
                    , o.CalculatedArea                 
                    , o.Description
                    , o.Id
                    , o.Id_FieldGroup
                    , o.LegalArea
                    , o.Locality
                    , o.Name
                    , o.SubadministrativeAreaName
                    , o.TillableArea
                    , FieldsGroupDescription = i.Description
                    , FieldsGroupFolderId = i.Id_GroupFolder
                    , FieldsGroupName = i.Name
                    , FieldsGroupSubadministrativeAreaName = i.SubadministrativeAreaName
                })
                .Join(LoadDataFromJsonFile<CO_History_Item>().Where(x => x.Year == DateTime.Now.Year), o => o.Id, i => i.Id_Field, (o, i) => new
                {
                    o.AdministrativeAreaName
                    , o.CalculatedArea
                    , o.Description
                    , o.Id
                    , o.Id_FieldGroup
                    , o.LegalArea
                    , o.Locality
                    , o.Name
                    , o.SubadministrativeAreaName
                    , o.TillableArea
                    , o.FieldsGroupDescription
                    , o.FieldsGroupFolderId
                    , o.FieldsGroupName
                    , o.FieldsGroupSubadministrativeAreaName
                    , i.Id_Crop
                    , HistoryItemIsActive = i.IsActive
                    , HistoryItemVariety = i.Variety
                    , HistoryItemDescription = i.Description
                })
                .Join(LoadDataFromJsonFile<CO_Crop>(), o => o.Id_Crop, i => i.Id
                    , (o, i) => new View_Field
                    {
                          AdministrativeAreaName                    = o.AdministrativeAreaName
                          , CalculatedArea                          = o.CalculatedArea
                          , Description                             = o.Description
                          , Id                                      = o.Id
                          , Id_FieldGroup                           = o.Id_FieldGroup
                          , LegalArea                               = o.LegalArea
                          , Locality                                = o.Locality
                          , Name                                    = o.Name
                          , SubadministrativeAreaName               = o.SubadministrativeAreaName
                          , TillableArea                            = o.TillableArea
                          , FieldsGroupDescription                  = o.FieldsGroupDescription
                          , Id_FieldsGroupFolder                     = o.FieldsGroupFolderId
                          , FieldsGroupName                         = o.FieldsGroupName
                          , FieldsGroupSubadministrativeAreaName    = o.FieldsGroupSubadministrativeAreaName
                          , Id_Crop                                 = o.Id_Crop
                          , HistoryItemIsActive                     = o.HistoryItemIsActive
                          , HistoryItemVariety                      = o.HistoryItemVariety
                          , HistoryItemDescription                  = o.HistoryItemDescription
                          , CropName                                = i.Name
                          , CropShortName                           = i.ShortName
                          , CropStandardName                        = i.StandardName
                    })
                .ToList();            
            return fields;
        }

        public static void SyncroniseData(CropioApi cropio)
        {
            String opName = "Synchronization";
            Int32 itemsCount = 11;
            Int32 curItem = 0;
            opName.ProgressBar(itemsCount, curItem++);
            SyncDataTable<CO_User>(cropio);
            opName.ProgressBar(itemsCount, curItem++);
            SyncDataTable<CO_UserRoleAssignment>(cropio);
            opName.ProgressBar(itemsCount, curItem++);
            SyncDataTable<CO_UserRole>(cropio);
            opName.ProgressBar(itemsCount, curItem++);
            SyncDataTable<CO_UserRolePermission>(cropio);
            opName.ProgressBar(itemsCount, curItem++);
            SyncDataTable<CO_FieldGroup>(cropio);
            opName.ProgressBar(itemsCount, curItem++);
            SyncDataTable<CO_Field>(cropio);
            opName.ProgressBar(itemsCount, curItem++);
            SyncDataTable<CO_History_Item>(cropio);
            opName.ProgressBar(itemsCount, curItem++);
            SyncDataTable<CO_History_InventoryItem>(cropio);
            opName.ProgressBar(itemsCount, curItem++);
            //
            SyncDataTable<CO_Alert>(cropio);
            opName.ProgressBar(itemsCount, curItem++);
            SyncDataTable<CO_AlertType>(cropio);
            opName.ProgressBar(itemsCount, curItem++);
            //
            SyncDataTable<CO_Crop>(cropio);
            opName.ProgressBar(itemsCount, curItem);
            Console.WriteLine();
        }

        public static void SyncDataTable<T>(CropioApi cropio) where T : ICropioRegularObject
        {
            if(!Directory.Exists(DirPath_LocalDataStorage)) Directory.CreateDirectory(DirPath_LocalDataStorage);
            List<T> data = LoadDataFromJsonFile<T>() ?? new List<T>();
            DateTime? updatedAt = data.Max(x => x.UpdatedAt);
            MassResponse_Changes changedObjs = cropio.GetChangedObjectsIds<T>(updatedAt);
            if(changedObjs.Data.Count == 0) return;
            List<T> updatedData = new List<T>();
            foreach(var ids in changedObjs.Data.Select(x => x.Id).Paginate(200)) 
                updatedData.AddRange(cropio.GetObjects<T>(ids).Data);
            data = data.Except(updatedData, (a, b) => a.Id == b.Id).ToList();
            data.AddRange(updatedData);
            data = data.OrderByDescending(x => x.UpdatedAt).ToList();
            data.SaveDataToJsonFile();
        }

        public static List<T> LoadDataFromJsonFile<T>() where T : ICropioRegularObject
        {
            String filePath_StoredObjs = Path.Combine(DirPath_LocalDataStorage, typeof(T).Name + ".json");
            if(!File.Exists(filePath_StoredObjs)) File.Create(filePath_StoredObjs).Close();
            List<T> data = new List<T>();

            using(StreamReader file = File.OpenText(filePath_StoredObjs))
            {
                using(JsonTextReader reader = new JsonTextReader(file))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    data = serializer.Deserialize<List<T>>(reader);
                }
            }
            return data;
        }

        public static void SaveDataToJsonFile<T>(this List<T> data) where T : ICropioRegularObject
        {
            String filePath_StoredObjs = Path.Combine(DirPath_LocalDataStorage, typeof(T).Name + ".json");
            if(!File.Exists(filePath_StoredObjs)) File.Create(filePath_StoredObjs).Close();
            using(StreamWriter sw = new StreamWriter(filePath_StoredObjs))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(sw, data);
            }
        }

        public static void ProgressBar(this String operationName, Int32 maxVal, Int32 curVal)
        {
            Console.Clear();
            if(curVal > maxVal) curVal = maxVal;
            Console.WriteLine($"{operationName} {new String('█', curVal * 2)}{new String('-', (maxVal - curVal) * 2)} {curVal}/{maxVal}");
        }
    } 
}
