using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Культура </summary>
    /// <remarks>
    /// Пример json-объекта находится в JsonSamples/crops.json
    /// 
    /// Связи:
    /// @ Id 
    /// @ Id_External
    /// </remarks>
    [JsonObject(Title = "crops")]
    public class CO_Crop : ICropioExtendetObject
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
        
        /// <summary> Название культуры </summary>
        [JsonProperty("name")]
        public String Name { get; set; }

        /// <summary> Краткое название культуры </summary>
        [JsonProperty("short_name")]
        public String ShortName { get; set; }

        /// <summary> Имя по умолчанию (предопределенное) </summary>
        [JsonConverter(typeof(JsonConverter_CropStandardName))]
        [JsonProperty("standard_name")]
        public CE_CropStandardName? StandardName { get; set; }

        /// <summary> Цвет выбранный для культуры в цветовой схеме </summary>
        [JsonProperty("color")]
        public String Color { get; set; }

        /// <summary> Дополнительная информация </summary>
        [JsonProperty("additional_info")]
        public String AdditionalInfo { get; set; }

        /// <summary> Описание </summary>
        [JsonProperty("description")]
        public String Description { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id: ").Append(Id)
                .Append(i).Append("Id_External:     ").Append(Id_External)
                .Append(i).Append("CreatedAt:       ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:       ").Append(UpdatedAt)
                .Append(i).Append("Name:            ").Append(Name)
                .Append(i).Append("ShortName:       ").Append(ShortName)
                .Append(i).Append("StandardName:    ").Append(StandardName)
                .Append(i).Append("Color:           ").Append(Color)
                .Append(i).Append("AdditionalInfo:  ").Append(AdditionalInfo)
                .Append(i).Append("Description:     ").Append(Description);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
