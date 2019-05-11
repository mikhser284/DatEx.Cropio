using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Агрегат </summary>
    /// <remarks>
    /// Пример json-объекта находится в JsonSamples/implements.json
    /// 
    /// Связи:
    /// @ Id 
    /// @ Id_External
    /// </remarks>
    [JsonObject(Title = "implements")]
    public class CO_Implement : ICropioExtendetObject
    {
        /// <summary> ID объекта в Cropio </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> ID объекта во внешней системе </summary>
        [JsonProperty("external_id")]
        public String Id_External { get; set; }

        /// <summary> Время создания объекта </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> Время последнего обновления объекта </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary> Название агрегата </summary>
        [JsonProperty("name")]
        public String Name { get; set; }
        
        /// <summary> Пользвательское название агрегата. (В случае если пользовательское название не задано название реализации будет задано как 'Производитель' + 'Модель) </summary>
        [JsonProperty("custom_name")]
        public String CustomName { get; set; }
        
        /// <summary> Модель </summary>
        [JsonProperty("model")]
        public String Model { get; set; }
        
        /// <summary> Производитель </summary>
        [JsonProperty("manufacturer")]
        public String Manufacturer { get; set; }
        
        /// <summary> Год производства </summary>
        [JsonProperty("year")]
        public Int32? Year { get; set; }
        
        /// <summary> Регистрационный номер </summary>
        [JsonProperty("registration_number")]
        public String RegistrationNumber { get; set; }
        
        /// <summary> Инвентарный номер </summary>
        [JsonProperty("inventory_number")]
        public String InventoryNumber { get; set; }
        
        /// <summary> Тип агрегата (принимает одно из значений: 'subsoiler', 'cultivator', 'planter', 'sprayer', 'spreader', 'lifter', 'bunker', 'cart', 
        /// 'harrow', 'graider', 'trailer', 'roller', 'reaper', 'compactor', 'baler', 'grass_handling', 'plow', 'other') </summary>
        [JsonConverter(typeof(JsonConverter_TypeOfImplement))]
        [JsonProperty("implement_type")]
        public CE_TypeOfImplement ImplementType { get; set; }
        
        /// <summary> Длина (м) </summary>
        [JsonProperty("width")]
        public Single Width { get; set; }
        
        /// <summary> Официальная длина (м) </summary>
        [JsonProperty("official_width")]
        public Single? OfficialWidth { get; set; }
        
        /// <summary> Аватар </summary>
        [JsonProperty("avatar")]
        [JsonConverter(typeof(JsonAvatarConverter))]
        public Avatar Avatar { get; set; }
        
        /// <summary> Серийный номер шасси </summary>
        [JsonProperty("chassis_serial_number")]
        public String ChassisSerialNumber { get; set; }
        
        /// <summary> Компания </summary>
        [JsonProperty("legal_company")]
        public String LegalCompany { get; set; }
        
        /// <summary> Описание </summary>
        [JsonProperty("description")]
        public String Description { get; set; }
        
        /// <summary> Дополнительно (сериализированная информация) </summary>
        [JsonProperty("additional")]
        public String Additional { get; set; }
        
        /// <summary> Дополнительная информация </summary>
        [JsonProperty("additional_info")]
        public String AdditionalInfo { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                  ").Append(Id)
                .Append(i).Append("CreatedAt:           ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:           ").Append(UpdatedAt)
                .Append(i).Append("Name:                ").Append(Name)
                .Append(i).Append("CustomName:          ").Append(CustomName)
                .Append(i).Append("Model:               ").Append(Model)
                .Append(i).Append("Manufacturer:        ").Append(Manufacturer)
                .Append(i).Append("Year:                ").Append(Year)
                .Append(i).Append("RegistrationNumber:  ").Append(RegistrationNumber)
                .Append(i).Append("InventoryNumber:     ").Append(InventoryNumber)
                .Append(i).Append("ImplementType:       ").Append(ImplementType.AsStringRu())
                .Append(i).Append("Width:               ").Append(Width.F("0.00 m"))
                .Append(i).Append("OfficialWidth:       ").Append(OfficialWidth.F("0.00 m"))
                .Append(i).Append("Avatar:              ").Append(Avatar)
                .Append(i).Append("ChassisSerialNumber: ").Append(ChassisSerialNumber)
                .Append(i).Append("LegalCompany:        ").Append(LegalCompany)
                .Append(i).Append("Description:         ").Append(Description)
                .Append(i).Append("Additional:          ").Append(Additional)
                .Append(i).Append("AdditionalInfo:      ").Append(AdditionalInfo);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
