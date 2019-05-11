using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Семена </summary>
    /// <remarks>
    /// Пример json-объекта находится в JsonSamples/seeds.json
    /// 
    /// Связи:
    /// @ Id 
    /// @ Id_External
    /// - Id_Crop -> CO_Crop.Id     (В JSON machine_id -> crops.id)
    /// </remarks>
    [JsonObject(Title = "seeds")]
    public class CO_Seed : ICropioExtendetObject
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

        /// <summary> your system info </summary>
        [JsonProperty("additional_info")]
        public String AdditionalInfo { get; set; }

        /// <summary> description </summary>
        [JsonProperty("description")]
        public String Description { get; set; }

        /// <summary> Название </summary>
        [JsonProperty("name")]
        public String Name { get; set; }

        /// <summary> Id связанного объекта CO_Seed (crops.id в json) </summary>
        [JsonProperty("crop_id")]
        public Int32 Id_Crop { get; set; }
        
        /// <summary> Сорт </summary>
        [JsonProperty("variety")]
        public String Variety { get; set; }
        
        /// <summary> Номер репродукции </summary>
        [JsonProperty("reproduction_number")]
        public Int32? ReproductionNumber { get; set; }
        
        /// <summary> Единица измерения (Одно из значений: 'units', 'tn', 'kg', 'pieces', 'thousand_pieces') </summary>
        [JsonConverter(typeof(JsonConverter_MeasureUnitOfSeed))]
        [JsonProperty("units_of_measurement")]
        public CE_MeasureUnitOfSeed UnitsOfMeasurement { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                  ").Append(Id)
                .Append(i).Append("Id_External:         ").Append(Id_External)
                .Append(i).Append("CreatedAt:           ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:           ").Append(UpdatedAt)
                .Append(i).Append("Name:                ").Append(Name)
                .Append(i).Append("Id_Crop:             ").Append(Id_Crop)
                .Append(i).Append("Variety:             ").Append(Variety)
                .Append(i).Append("ReproductionNumber:  ").Append(ReproductionNumber)
                .Append(i).Append("AdditionalInfo:      ").Append(AdditionalInfo)
                .Append(i).Append("Description:         ").Append(Description)
                .Append(i).Append("UnitsOfMeasurement:  ").Append(UnitsOfMeasurement)
                ;
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
