using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Химикаты </summary>
    /// <remarks>
    /// Пример json-объекта находится в JsonSamples/chemicals.json
    /// 
    /// Связи:
    /// @ Id 
    /// </remarks>
    [JsonObject(Title = "chemicals")]
    public class CO_Chemical : ICropioExtendetObject
    {
        /// <summary> ID объекта в системе Cropio </summary>
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

        /// <summary> Название химиката </summary>
        [JsonProperty("name")]
        public String Name { get; set; }

        /// <summary> Тип химиката (одно из следующих значений: 'bactericide', 'herbicide', 'insecticide', 'fungicide', 'growth_regulator', 'seed_treatment', 'other' </summary>
        [JsonConverter(typeof(JsonConverter_TypeOfChemical))]
        [JsonProperty("chemical_type")]
        public CE_TypeOfChemical ChemicalType { get; set; }

        /// <summary> Единицы измерения (одно из следующих значений: 'liter', 'kg') </summary>
        [JsonConverter(typeof(JsonConverter_MeasureUnitOfChemical))]
        [JsonProperty("units_of_measurement")]
        public CE_MeasureUnitOfChemical UnitsOfMeasurement { get; set; }

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
                .Append(i).Append("Id:                  ").Append(Id)
                .Append(i).Append("Id_External:         ").Append(Id_External)
                .Append(i).Append("CreatedAt:           ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:           ").Append(UpdatedAt)
                .Append(i).Append("Name:                ").Append(Name)
                .Append(i).Append("ChemicalType:        ").Append(ChemicalType)
                .Append(i).Append("UnitsOfMeasurement:  ").Append(UnitsOfMeasurement)
                .Append(i).Append("AdditionalInfo:      ").Append(AdditionalInfo)
                .Append(i).Append("Description:         ").Append(Description);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
