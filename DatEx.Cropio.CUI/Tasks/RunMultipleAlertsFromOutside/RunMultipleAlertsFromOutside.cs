﻿using System;
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
        public const String DirPath_LocalDataStorage = @"..\..\..\!Data";

        public static void SyncroniseData(CropioApi cropio)
        {
            Console.WriteLine("CO_User");
            SyncDataTable<CO_User>(cropio);
            Console.WriteLine("CO_UserRoleAssignment");
            SyncDataTable<CO_UserRoleAssignment>(cropio);
            Console.WriteLine("CO_UserRolePermission");
            SyncDataTable<CO_UserRolePermission>(cropio);
            Console.WriteLine("CO_FieldGroup");
            SyncDataTable<CO_FieldGroup>(cropio);
            Console.WriteLine("CO_Field");
            SyncDataTable<CO_Field>(cropio);
            Console.WriteLine("CO_History_InventoryItem");
            SyncDataTable<CO_History_InventoryItem>(cropio);
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
            data = data.OrderByDescending(x => x.CreatedAt).ToList();
            data.SaveDataToJsonFile();
        }

        public static List<T> LoadDataFromJsonFile<T>() where T : ICropioRegularObject
        {
            String filePath_StoredObjs = Path.Combine(DirPath_LocalDataStorage, typeof(T).Name + ".json");
            if(!File.Exists(filePath_StoredObjs)) File.Create(filePath_StoredObjs).Close();
            List<T> data = new List<T>();

            //TODO load data from json file
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
    }

    
}