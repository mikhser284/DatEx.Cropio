using DatEx.Cropio.BaseAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DatEx.Cropio.Config;
// Comment changed
namespace DatEx.Cropio.CUI
{
    class Program
    {
        private static CropioApi GetCropioClient()
        {
            ConnectionInfo connectionInfo = Applitation.UsedConnection;
            return new CropioApi(connectionInfo.ServerBaseAddress, connectionInfo.AgentLogin, connectionInfo.AgentPassword);
        }

        static void Main(String[] args)
        {
            CropioApi cropio = GetCropioClient();
            RunMultipleAlertsFromOutside.Main(cropio);

            //var resp = cropio.GetObjectsIds<CO_AlertType>();
            //foreach(var ids in resp.Data.Paginate(100))
            //{
            //    var resp2 = cropio.GetObjects<CO_AlertType>(ids);
            //    foreach(var obj in resp2.Data)
            //    {
            //        Console.WriteLine(obj.GetTextView(1));
            //    }
            //}
        }

        public static void Task03_CreatingMultipleAlertsOutsideCropio()
        {
            CropioApi cropio = GetCropioClient();
            CropioTest.ShowFields(cropio);

            cropio.ShowUsersPermissions();
            cropio.ShowAlertTypes();
            cropio.CreateAllerts();
            return;
            HashSet<Int32> fields = new HashSet<int> { 208 };
            //var fields = cropio.GetObjects<CO_Field>(new List<Int32> { 208, 160, 170 });
            //foreach(var f in fields.Data)
            //{
            //    Console.WriteLine("------------------");
            //    Console.WriteLine(f);
            //}

            var histItem = cropio.GetObjects<CO_History_Item>(cropio.GetObjectsIds<CO_History_Item>().Data).Data;
            foreach(var f in fields)
            {
                Console.WriteLine("---------- Field ID: {0}", f);
                foreach (var i in histItem)
                {
                    if(i.Id_Field != f) continue;
                    Console.WriteLine(i);
                    Console.WriteLine("\n*****");
                    
                }
            }
        }

        /// <summary> Сохранить объекты связанные с агрооперациями в файлы </summary>
        public static void SaveAgroOperationRelatedObjects()
        {
            CropioApi cropio = GetCropioClient();
            Console.WriteLine("Получение объектов из Cropio ...\n");
            //
            cropio.SaveJsonObjectsToFile<CO_AgroOperation>();
            cropio.SaveJsonObjectsToFile<CO_AgriWorkPlan>();
            cropio.SaveJsonObjectsToFile<CO_ApplicationMixItem>();
            cropio.SaveJsonObjectsToFile<CO_Chemical>();
            cropio.SaveJsonObjectsToFile<CO_Crop>();
            cropio.SaveJsonObjectsToFile<CO_Fertilizer>();
            cropio.SaveJsonObjectsToFile<CO_Field>();
            cropio.SaveJsonObjectsToFile<CO_FieldGroup>();
            cropio.SaveJsonObjectsToFile<CO_FieldShape>();
            cropio.SaveJsonObjectsToFile<CO_GroupFolder>();
            cropio.SaveJsonObjectsToFile<CO_Implement>();
            cropio.SaveJsonObjectsToFile<CO_Machine>();
            cropio.SaveJsonObjectsToFile<CO_MachineGroup>();
            cropio.SaveJsonObjectsToFile<CO_MachineTask>();
            cropio.SaveJsonObjectsToFile<CO_Seed>();
            cropio.SaveJsonObjectsToFile<CO_User>();
            cropio.SaveJsonObjectsToFile<CO_WorkType>();
            cropio.SaveJsonObjectsToFile<CO_WorkTypeGroup>();
            //
            Console.WriteLine("\nПолучение всех объектов завершено\n");
        }

        /// <summary> Сохранить докумен, прикрепленный к тревоге </summary>
        public static void SaveAlertRelatedDocuments(Int32 idAlertWithDocument = 498)
        {
            CropioApi cropio = GetCropioClient();
            //
            String fileFullName = "";
            //Int32 idAlertWithoutoDcuments = 507;
            MassResponse<CO_Document> doc = cropio.ObjRelatedDocument<CO_Alert>(idAlertWithDocument);
            //Console.WriteLine(doc);
            if(doc.Data.Count == 0) return;
            
            foreach(CO_Document document in doc.Data)
            {
                //Console.WriteLine(document.DocumentUrl);

                Console.WriteLine(Path.GetFileName(Uri.UnescapeDataString(document.DocumentUrl)));
                if(!String.IsNullOrWhiteSpace(fileFullName))
                {
                    Byte[] fileBody = cropio.DownloadDocumentFile(document.Id);
                    File.WriteAllBytes(fileFullName, fileBody);
                }
            }
        }

        /// <summary> Показать поля и актуальные тревоги </summary>
        public static void ShowFieldsAndActualAlerts()
        {
            CropioApi cropio = GetCropioClient();
            cropio.ShowFields();
            //cropio.ShowActualAlerts();
        }

    }

    

    public static class Task03_CreatingMultipleAlertsOutsideCropio
    {
        public static void ShowUsersPermissions(this CropioApi cropio)
        {
            Console.WriteLine("Получение пользователей");
            List<CO_User> users = cropio.GetObjects<CO_User>(cropio.GetObjectsIds<CO_User>().Data).Data.OrderBy(x => x.UserName).ToList();

            Console.WriteLine("Получение связей Роль—Пользователь\n");
            Dictionary<Int32, List<CO_UserRoleAssignment>> userRoleAssignments = cropio.GetObjects<CO_UserRoleAssignment>(cropio.GetObjectsIds<CO_UserRoleAssignment>().Data)
                .Data.ToDictionaryList(x => x.Id_User);

            Console.WriteLine("Получение ролей");
            Dictionary<Int32, CO_UserRole> userRoles = cropio.GetObjects<CO_UserRole>(cropio.GetObjectsIds<CO_UserRole>().Data).Data.ToDictionary(x => x.Id);

            Console.WriteLine("Получение полномочий ролей");
            Dictionary<Int32, List<CO_UserRolePermission>> rolePermissions = cropio.GetObjects<CO_UserRolePermission>(cropio.GetObjectsIds<CO_UserRolePermission>().Data)
                .Data.ToDictionaryList(x => x.Id_UserRole);

            Console.WriteLine("Получение групп полей.");
            Dictionary<Int32, CO_FieldGroup> fieldGroups = cropio.GetObjects<CO_FieldGroup>(cropio.GetObjectsIds<CO_FieldGroup>().Data).Data.ToDictionary(x => x.Id);

            Console.WriteLine("Получение полей.");
            Dictionary<Int32, List<CO_Field>> fields = cropio.GetObjects<CO_Field>(cropio.GetObjectsIds<CO_Field>().Data).Data.ToDictionaryList(x => x.Id_FieldGroup);

            Console.WriteLine("Построение ...\n\n");
            foreach(var user in users)
            {
                if(String.IsNullOrEmpty(user.Description) || !user.Description.Contains("[#CanRunAlertsFromElma]")) continue;
                if(!userRoleAssignments.ContainsKey(user.Id)) continue;
                Console.WriteLine("\n\n{0, -6} | {1}", user.Id, user.UserName);
                foreach(var ura in userRoleAssignments[user.Id])
                {
                    if(!userRoles.ContainsKey(ura.Id_UserRole)) continue;
                    var userRole = userRoles[ura.Id_UserRole];
                    Console.WriteLine("     {0}", userRole.Name);
                    if(!rolePermissions.ContainsKey(userRole.Id)) continue;
                    foreach(var i in rolePermissions[userRole.Id])
                    {
                        if(i.AccessFor != CE_AccessFor.Fields || i.AccessLevel == CE_AccessLevel.NoAccess || i.SubjectType != CE_UserRolePermissionSubjectType.FieldGroup) continue;
                        if(!fieldGroups.ContainsKey(i.Id_Subject)) continue;
                        var fieldGroup = fieldGroups[i.Id_Subject];
                        Console.WriteLine("          {0}", fieldGroup.Name);
                        if(!fields.ContainsKey(fieldGroup.Id)) continue;
                        foreach(var field in fields[fieldGroup.Id].OrderBy(x => x.Name))
                        {
                            Console.WriteLine("               {0, -4} | {1}", field.Id, field.Name);
                        }
                    }
                }
            }
        }        

        public static void ShowAlertTypes(this CropioApi cropio)
        {
            List<CO_AlertType> alertTypes = cropio.GetObjects<CO_AlertType>(cropio.GetObjectsIds<CO_AlertType>().Data).Data;
            foreach(var item in alertTypes)
            {
                if(String.IsNullOrEmpty(item.AdditionalInfo) || !item.AdditionalInfo.Contains("[#Run in ELMA]")) continue;
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        public static void CreateAllerts(this CropioApi cropio)
        {
            // 01 - Насекомые
            // 04 - Сорняки
            // 05 - Заболование
            // 06 - Другое
            // 07 - погодные условия
            // 08 - Уровень развития растений
            // ---
            // 16153 - Кирильчук Павел Александрович
            // ---
            //
            CO_Alert alert01 = new CO_Alert
            {
                Status = CE_StatusOfAllert.Open,
                Description = "[TEST] Тревога создана программным образом.",
                CreatedAt = DateTime.Now,
                EventStartTime = DateTime.Now,
                Id_AlertType = 6,
                AlertableObjectType = CE_AlertableObjectType.Field,
                Id_AlertableObject = 208, // КАФ, VPL01
                Id_CreatedByUser = 16153, // Кирильчук Павел Александрович
                Id_ResponsiblePerson = 16153 // Кирильчук Павел Александрович
            };
            CO_Alert alert02 = new CO_Alert
            {
                Status = CE_StatusOfAllert.Open,
                Description = "[TEST] Тревога создана программным образом.",
                CreatedAt = DateTime.Now,
                EventStartTime = DateTime.Now,
                Id_AlertType = 6,
                AlertableObjectType = CE_AlertableObjectType.Field,
                Id_AlertableObject = 160, // КАХ, VBK01
                Id_CreatedByUser = 16153, // Кирильчук Павел Александрович
                Id_ResponsiblePerson = 16153 // Кирильчук Павел Александрович
            };
            CO_Alert alert03 = new CO_Alert
            {
                Status = CE_StatusOfAllert.Open,
                Description = "[TEST] Тревога создана программным образом.",
                CreatedAt = DateTime.Now,
                EventStartTime = DateTime.Now,
                Id_AlertType = 6,
                AlertableObjectType = CE_AlertableObjectType.Field,
                Id_AlertableObject = 170, // КАХ, VCH01
                Id_CreatedByUser = 16153, // Кирильчук Павел Александрович
                Id_ResponsiblePerson = 16153 // Кирильчук Павел Александрович
            };
            //
            Console.WriteLine(cropio.CreateObject(alert01));
            Console.WriteLine(cropio.CreateObject(alert02));
            Console.WriteLine(cropio.CreateObject(alert03));
        }
    }

    public static class CropioTest
    {
        public static void Create(this CropioApi cropio)
        {
            CO_Alert alert = new CO_Alert
            {
                Status = CE_StatusOfAllert.Open,
                AlertableObjectType = CE_AlertableObjectType.Field,
                Description = "[TEST] Тревога создана программным образом.",
                CreatedAt = DateTime.Now,
                EventStartTime = DateTime.Now,
                Id_AlertType = 1,
                Id_AlertableObject = 21,
                Id_CreatedByUser = 33481,
                Id_ResponsiblePerson = 9913
            };

            Console.WriteLine(cropio.CreateObject(alert));
        }

        public static void Update(this CropioApi cropio)
        {
            Response<CO_Alert> resp_alert = cropio.GetObject<CO_Alert>(433);

            if(resp_alert.CropioResponse.IsSuccess)
            {
                CO_Alert alert = resp_alert.Data;
                //alert.Id_ResponsiblePerson = 9913;
                alert.Id_AlertableObject = 21;
                alert.Description += "\n[TEST] Тревога изменена программным образом.";

                Console.WriteLine(cropio.UpdateObject(alert));
            }
        }

        public static void Delete(this CropioApi cropio)
        {
            Console.WriteLine(cropio.DeleteObject<CO_Alert>(433));
        }

        public static void ShowObjects<T>(this CropioApi cropio, IEnumerable<Int32> ids) where T : ICropioRegularObject
        {
            cropio.ShowObjects<T>(ids.ToArray());
        }

        public static void ShowObjects<T>(this CropioApi cropio, params Int32[] objIds) where T : ICropioRegularObject
        {
            MassResponse<T> result = cropio.GetObjects<T>(objIds);
            if(result.Data == null)
            {
                Console.WriteLine("Data == null"); return;
            }
            foreach(T obj in result.Data)
            {
                Console.WriteLine("\n\n————— {0,6} ({1}) ——————————————————————————————————————", obj.Id, CropioDataModel.Name<T>());
                Console.WriteLine(obj);
            }
        }

        public static void ShowChangedObjects(this CropioApi cropio, DateTime timeOfLastSuccessfulSynchronization)
        {
            DateTime currentTime = DateTime.Now;
            Console.WriteLine("Получение полей.");
            MassResponse_Changes fields = cropio.GetChangedObjectsIds<CO_Field>(timeOfLastSuccessfulSynchronization);
            Console.WriteLine("Получение групп полей.");
            MassResponse_Changes fieldGroups = cropio.GetChangedObjectsIds<CO_FieldGroup>(timeOfLastSuccessfulSynchronization);
            Console.WriteLine("Получение елементов истории.");
            MassResponse_Changes historyItems = cropio.GetChangedObjectsIds<CO_History_Item>(timeOfLastSuccessfulSynchronization);
            Console.WriteLine("Получение елементов истории инвентаря.");
            MassResponse_Changes inventoryHistoryItems = cropio.GetChangedObjectsIds<CO_History_InventoryItem>(timeOfLastSuccessfulSynchronization);
            Console.WriteLine("Получение культур.");
            MassResponse_Changes crops = cropio.GetChangedObjectsIds<CO_Crop>(timeOfLastSuccessfulSynchronization);
            Console.WriteLine("Получение тревог.");
            MassResponse_Changes alerts = cropio.GetChangedObjectsIds<CO_Alert>(timeOfLastSuccessfulSynchronization);
            Console.WriteLine("Получение типов тревог.");
            MassResponse_Changes alertTypes = cropio.GetChangedObjectsIds<CO_AlertType>(timeOfLastSuccessfulSynchronization);
            Console.WriteLine("Получение пользователей.");
            MassResponse_Changes users = cropio.GetChangedObjectsIds<CO_User>(timeOfLastSuccessfulSynchronization);

            StringBuilder sb = new StringBuilder()
                .Append("\n fields:                ").Append(GetChangedObjectsTextInfo(fields))
                .Append("\n fieldGroups:           ").Append(GetChangedObjectsTextInfo(fieldGroups))
                .Append("\n historyItems:          ").Append(GetChangedObjectsTextInfo(historyItems))
                .Append("\n inventoryHistoryItems: ").Append(GetChangedObjectsTextInfo(inventoryHistoryItems))
                .Append("\n crops:                 ").Append(GetChangedObjectsTextInfo(crops))
                .Append("\n alerts:                ").Append(GetChangedObjectsTextInfo(alerts))
                .Append("\n alertTypes:            ").Append(GetChangedObjectsTextInfo(alertTypes))
                .Append("\n users:                 ").Append(GetChangedObjectsTextInfo(users));
            Console.WriteLine(sb.ToString());
        }

        public static String GetChangedObjectsTextInfo(this MassResponse_Changes changes)
        {
            ChangesResponse x = changes.Meta.Response;
            return String.Format("{0,8} records (from {1} till {2})", x.ObtainedRecords, x.FirstRecordTime, x.LastRecordTime);
        }
        
        public static void ShowHistoryInventoryItemTypes(this CropioApi cropio)
        {
            Console.WriteLine("Получение идентификаторов для для таблицы CO_History_InventoryItem");
            IEnumerable<IEnumerable<Int32>> ids = cropio.GetObjectsIds<CO_History_InventoryItem>().Data.Paginate(500);
            HashSet<CE_HistoryableType> historyableTypes = new HashSet<CE_HistoryableType>();
            Int32 itemNo = 0;

            foreach (IEnumerable<Int32> page in ids)
            {
                MassResponse<CO_History_InventoryItem> objects = cropio.GetObjects<CO_History_InventoryItem>(page);
                foreach (CO_History_InventoryItem obj in objects.Data)
                {
                    if(historyableTypes.Contains(obj.HistoryableType)) continue;
                    historyableTypes.Add(obj.HistoryableType);
                    Console.WriteLine("{0, 4} {1}", itemNo, obj.HistoryableType);
                }
            }
        }

        public static void ShowFields(this CropioApi cropio)
        {
            Console.WriteLine("Получение полей.");
            List<CO_Field> fields = cropio.GetObjects<CO_Field>(cropio.GetObjectsIds<CO_Field>().Data).Data;
            //
            Console.WriteLine("Получение групп полей.");
            List<CO_FieldGroup> fieldGroups = cropio.GetObjects<CO_FieldGroup>(cropio.GetObjectsIds<CO_FieldGroup>().Data).Data;
            //
            Console.WriteLine("Получение елементов истории.");
            List<CO_History_Item> historyItems = cropio.GetObjects<CO_History_Item>(cropio.GetObjectsIds<CO_History_Item>().Data).Data;
            //
            Console.WriteLine("Получение елементов истории инвентаря.");
            List<CO_History_InventoryItem> inventoryHistoryItems = cropio.GetObjects<CO_History_InventoryItem>(cropio.GetObjectsIds<CO_History_InventoryItem>().Data).Data;
            //
            Console.WriteLine("Получение культур.");
            List<CO_Crop> crops = cropio.GetObjects<CO_Crop>(cropio.GetObjectsIds<CO_Crop>().Data).Data;
            //
            Console.WriteLine("Получение тревог.");
            List<CO_Alert> alerts = cropio.GetObjects<CO_Alert>(cropio.GetObjectsIds<CO_Alert>().Data).Data;
            //
            Console.WriteLine("Получение типов тревог.");
            List<CO_AlertType> alertTypes = cropio.GetObjects<CO_AlertType>(cropio.GetObjectsIds<CO_AlertType>().Data).Data;
            //
            Console.WriteLine("Получение пользователей.");
            List<CO_User> users = cropio.GetObjects<CO_User>(cropio.GetObjectsIds<CO_User>().Data).Data;
            //
            Console.WriteLine("Получение информации завершено\n\n.");

            const String filePath = @"..\..\..\DatEx.Cropio.Log\Output.txt";

            foreach (CO_Field f in fields)
            {
                CO_FieldGroup fg = fieldGroups.FirstOrDefault(x => x.Id == f.Id_FieldGroup);
                CO_History_Item hi = historyItems.FirstOrDefault(x => x.Id_Field == f.Id && x.Year == DateTime.Now.Year);
                List<CO_History_InventoryItem> ih = inventoryHistoryItems.Where(x => x.HistoryableType == CE_HistoryableType.Field && x.Id_Historyable == f.Id).ToList();
                List<CO_Alert> al = alerts.Where(x => x.AlertableObjectType == CE_AlertableObjectType.Field && x.Id_AlertableObject == f.Id).ToList();


                String cropName = String.Empty;
                if (hi.Id_Crop != null)
                {
                    CO_Crop crop = crops.FirstOrDefault(x => x.Id == hi.Id_Crop);
                    cropName = crop == null ? "—" : crop.Name;
                }
                StringBuilder sb = new StringBuilder()
          .Append(String.Format("\n ─────────────────────── {0, -5} ────────────────────────────────────\n", f.Id))
                        .Append("\n End time:                ").Append(f.EndTime)
                        .Append("\n Название поля:           ").Append(f.Name)
                        .Append("\n Группа полей:            ").Append(fg.Name)
                        .Append("\n Область:                 ").Append(f.AdministrativeAreaName)
                        .Append("\n Район:                   ").Append(f.SubadministrativeAreaName)
                        .Append("\n Село:                    ").Append(f.Locality)
                        .Append("\n Описание:                ").Append(f.Description)
                        .Append("\n Культура:                ")
                        .Append("\n    Название:             ").Append(cropName)
                        .Append("\n    Сорт:                 ").Append(hi.Variety)
                        .Append("\n    Урожайность:          ").Append(hi.Productivity).Append(" ц/га")
                        .Append("\n    Оценка урожайности:   ").Append(hi.ProductivityEstimate).Append(" ц/га")
                        .Append("\n    Обработка почвы:      ").Append(hi.TillType)
                        .Append("\n    Тип орошения          ").Append("?")
                        .Append("\n    Дата сева:            ").Append(hi.SowingDate)
                        .Append("\n    Дата уборки:          ").Append(hi.HarvestingDate)
                        .Append("\n    Дополнительная инфо.: ").Append(hi.AdditionalInfo)
                        .Append("\n Площадь:                 ")
                        .Append("\n    Обрабатываемая:       ").Append(f.TillableArea).Append(" га")
                        .Append("\n    Официальная:          ").Append(f.LegalArea).Append(" га")
                        .Append("\n    Расчетная:            ").Append(f.CalculatedArea).Append(" га")
                        .Append("\n ■ Применение инвентаря:  ")
                        .Append("\n {");
                Int32 itemNo = 0;
                foreach (CO_History_InventoryItem i in ih)
                {
                    sb
                        .Append("\n    ♦♦♦ ─────────────────       ").Append(itemNo++)
                        .Append("\n    ID:                       ").Append(i.Id)
                        .Append("\n    CreatedAt:                ").Append(i.CreatedAt)
                        .Append("\n    UpdatedAt:                ").Append(i.UpdatedAt)
                        .Append("\n    Запись вступает в силу с: ").Append(i.RecordComesIntoEffectAt)
                        .Append("\n    Запись утрачивает силу с: ").Append(i.RecordComesOutOfEffectAt)
                        .Append("\n    Доступно:                 ").Append(i.IsAvailable)
                        .Append("\n    Скрыто:                   ").Append(i.IsHidden)
                        .Append("\n    Причина:                  ").Append(i.Reason)
                        .Append("\n    Описание:                 ").Append(i.Description)
                        .Append("\n    Тип:                      ").Append(i.HistoryableType);
                }
                sb      .Append("\n }")
                        .Append("\n ■ Тревоги:                ")
                        .Append("\n {");
                itemNo = 0;
                foreach (CO_Alert a in al)
                {
                    if(a == null) continue;
                    CO_User auth = users.FirstOrDefault(x => x.Id == a.Id_CreatedByUser);
                    
                    CO_User resp = users.FirstOrDefault(x => x.Id == a.Id_ResponsiblePerson);

                    CO_AlertType at = alertTypes.FirstOrDefault(x => x.Id == a.Id_AlertType);
                    sb
                        .Append("\n    # ───────────────────── ").Append(itemNo++)
                        .Append("\n    ID:                     ").Append(a.Id)
                        .Append("\n    Время создания:         ").Append(a.CreatedAt)
                        .Append("\n    Время изменения:        ").Append(a.UpdatedAt)
                        .Append("\n    Начало события:         ").Append(a.EventStartTime)
                        .Append("\n    Завершения события:     ").Append(a.EventStopTime)
                        .Append("\n    Время закрытия тревоги: ").Append(a.AlertClosedAt)
                        .Append("\n    Статус:                 ").Append(a.Status)
                        .Append("\n    Описание:               ").Append(a.Description);
                        if(auth != null) sb.Append("\n    Тревога создана:        ").Append(String.Format("{0} ({1})", auth.UserName, auth.Position));
                        if(resp != null) sb.Append("\n    Ответственная особа:    ").Append(String.Format("{0} ({1})", resp.UserName, resp.Position));
                        sb.Append("\n    Id_AutomaticAlert:      ").Append(a.Id_AutomaticAlert);
                    if(at == null) continue;
                    sb
                        .Append("\n    Тип тревоги:            ")
                        .Append("\n         Тип тревоги:       ").Append(at.AlertType)
                        .Append("\n         Название:          ").Append(at.Name)
                        .Append("\n         Приоритет:         ").Append(at.Priority)
                        .Append("\n         Описание:          ").Append(at.Description)
                        .Append("\n         Доп. инфо.:        ").Append(at.AdditionalInfo)
                        .Append("\n         Архивировано:      ").Append(at.IsArchived);
                }
                sb.Append("\n }");
                String result = sb.ToString();
                File.AppendAllText(filePath, result);
                Console.WriteLine(result);
                Console.ReadKey();
            }
        }

        public static void ShowAllObjectTypes(this CropioApi cropio)
        {
            
            MassResponse<Int32> ids = cropio.GetObjectsIds<CO_Version>();
            HashSet<String> typeNames = new HashSet<String>();
            Int32 itemNo = 0;
            
            foreach (IEnumerable<Int32> page in ids.Data.Paginate(1000))
            {
                MassResponse<CO_Version> objects = cropio.GetObjects<CO_Version>(page);
                if(!objects.CropioResponse.IsSuccess) continue;

                foreach (CO_Version obj in objects.Data)
                {
                    if (typeNames.Contains(obj.ItemType)) continue;
                    typeNames.Add(obj.ItemType);
                    Console.Write("\n{0:00} {1,-100}   ", ++itemNo, obj.ItemType);
                }
                Console.Write(".");
            }
            Console.WriteLine("Finished");
        }
        
        public static void ShowAllObjectsOlderThan<T>(this CropioApi cropio, DateTime time) where T : ICropioRegularObject
        {
            
            MassResponse_Changes res = cropio.GetChangedObjectsIds<T>(time);
            if(!res.CropioResponse.IsSuccess) { Console.WriteLine("error"); return; }
            Int32 recordNo = 0;
            foreach(var page in res.Data.Select(x => x.Id).Paginate(200))
            {
                MassResponse<T> ret = cropio.GetObjects<T>(page);
                if(!ret.CropioResponse.IsSuccess) { Console.WriteLine("error"); return; }
                foreach(var obj in ret.Data)
                {
                    Console.WriteLine("\n─────{0}───────────────────────────────────────────────────────",  (recordNo++).ToString().PadLeft(10, '─'));
                    Console.WriteLine(obj);
                }
            }
        }

        public static void ShowActualAlerts(this CropioApi cropio, Int32 recordsPerPage = 200)
        {
            MassResponse<Int32> alertTypesIds = cropio.GetObjectsIds<CO_AlertType>();
            if(alertTypesIds.Data == null) { Console.WriteLine("Identifiers not found"); return; }
            MassResponse<CO_AlertType> alertTypes = cropio.GetObjects<CO_AlertType>(alertTypesIds.Data);
            HashSet<Int32> valuableAlertTypesIds = new HashSet<int> (alertTypes.Data.Where(x => x.AdditionalInfo.Contains("[#Run in ELMA]")).Select(x => x.Id));

            List<CO_Alert> activeAlerts = new List<CO_Alert>();
            MassResponse<Int32> alertsIds = cropio.GetObjectsIds<CO_Alert>();
            if(alertsIds.Data == null) { Console.WriteLine("Identifiers not found"); return; }

            foreach(var idsPage in alertsIds.Data.Paginate(recordsPerPage))
            {
                MassResponse<CO_Alert> objs = cropio.GetObjects<CO_Alert>(idsPage);
                activeAlerts.AddRange(objs.Data.Where(x => x.Status != CE_StatusOfAllert.Closed && valuableAlertTypesIds.Contains(x.Id_AlertType)));
            }

            foreach(CO_Alert alert in activeAlerts)
            {
                Console.WriteLine(alert);
                Console.WriteLine("———————————————————————————————");
            }
        }

        public static void ShowAllObjects<T>(this CropioApi cropio, Boolean showNextItemAutomated = false) where T : ICropioRegularObject
        {
            const Int32 recordsPerPage = 200;
            MassResponse<Int32> ids = cropio.GetObjectsIds<T>();
            if(ids.Data == null) { Console.WriteLine("Identifiers not found"); return; }

            Int32 pagesCount = (Int32) Math.Ceiling((Double) ids.Data.Count / (Double) recordsPerPage);
            Int32 recordNo = 0;
            for (Int32 pageNumber = 0; pageNumber < pagesCount; pageNumber++)
            {
                Int32 startIndex = pageNumber * recordsPerPage;
                Int32 recordsCount = (startIndex + recordsPerPage) < ids.Data.Count
                    ? recordsPerPage
                    : ids.Data.Count - startIndex;
                List<Int32> idsSubSet = ids.Data.GetRange(startIndex,  recordsCount);
                //
                MassResponse<T> result = cropio.GetObjects<T>(idsSubSet);
                if(result.Data == null) { Console.WriteLine("Data == null"); break; }
                foreach (T obj in result.Data)
                {
                    Console.WriteLine("\n─────{0}───────────────────────────────────────────────────────",  (recordNo++).ToString().PadLeft(10, '─'));
                    Console.WriteLine(obj);
                    if (showNextItemAutomated) continue;
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        public static void ShowAllObjects_Slowly<T>(this CropioApi cropio, Boolean showNextItemAutomated = false) where T : ICropioRegularObject
        {
            MassResponse<Int32> ids = cropio.GetObjectsIds<T>();
            if(ids.Data == null) { Console.WriteLine("Identifiers not found"); return; }
            foreach (Int32 id in ids.Data)
            {
                Response<T> resp = cropio.GetObject<T>(id);
                Console.WriteLine(resp.Data);
                if (showNextItemAutomated) continue;
                Console.ReadKey();
                Console.Clear();
            }
        }
        
        public static void ShowIds<T>(this CropioApi cropio) where T : ICropioRegularObject
        {
            Console.WriteLine(CropioDataModel.Name<T>());
            MassResponse<Int32> ids = cropio.GetObjectsIds<T>();
            if (ids.Data == null) { Console.WriteLine("Data == null"); return; }
            Console.WriteLine(String.Join(", ", ids.Data.Select(x => x.ToString().PadLeft(8))));
        }

        public static void ShowItemNo<T>(this CropioApi cropio, Int32 itemNo) where T : ICropioRegularObject
        {
            MassResponse<Int32> ids = cropio.GetObjectsIds<T>();
            if(ids.Data == null)
            {
                Console.WriteLine("Data == null");
                return;
            }
            cropio.ShowObject<T>(ids.Data[itemNo]);
        }

        public static void ShowObject<T>(this CropioApi cropio, Int32 objId) where T : ICropioRegularObject
        {
            Response<T> obj = cropio.GetObject<T>(objId);
            if (obj == null || obj.Data == null) return;
            Console.WriteLine("\n\n————— {0,6} ({1}) ——————————————————————————————————————", objId, CropioDataModel.Name<T>());
            Console.WriteLine(obj.Data);
        }

        public static HashSet<T2> GetUniqueValues<T, T2>(this CropioApi cropio, Func<T, T2> selector) where T : ICropioRegularObject
        {
            HashSet<T2> uniqueValues = new HashSet<T2>();
            const Int32 recordsPerPage = 200;
            MassResponse<Int32> ids = cropio.GetObjectsIds<T>();
            if(ids.Data == null) { Console.WriteLine("Identifiers not found"); return uniqueValues; }
            //
            foreach(var page in ids.Data.Paginate(recordsPerPage))
            {
                MassResponse<T> objects = cropio.GetObjects<T>(page);
                IEnumerable<T2> values = objects.Data.DistinctValues(selector);
                foreach(T2 value in values) uniqueValues.Add(value);
            }
            return uniqueValues;
        }

        public static void ShowDistinctValues<T1, T2>(this CropioApi cropio, Func<T1, T2> selector) where T1 : ICropioRegularObject
        {
            List<T2> values = cropio.GetUniqueValues<T1, T2>(selector).OrderBy(X => X).ToList();
            foreach(var value in values) Console.WriteLine(value);
        }
    }
}
