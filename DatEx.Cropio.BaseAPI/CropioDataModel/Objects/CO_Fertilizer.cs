using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Удобрение </summary>
    /// <remarks>
    /// Пример json-объекта находится в JsonSamples/fertilizers.json
    /// 
    /// Связи:
    /// @ Id 
    /// @ Id_External
    /// </remarks>
    [JsonObject(Title = "fertilizers")]
    public class CO_Fertilizer : ICropioExtendetObject
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
        
        /// <summary> Тип удобрения: 'granular', 'liquid', 'organic' </summary>
        [JsonConverter(typeof(JsonConverter_TypeOfFertilizer))]
        [JsonProperty("fertilizer_type")]
        public CE_TypeOfFertilizer FertilizerType { get; set; }
        
        /// <summary> Дополнительная информация </summary>
        [JsonProperty("additional_info")]
        public String AdditionalInfo { get; set; }

        /// <summary> Описание </summary>
        [JsonProperty("description")]
        public String Description { get; set; }

        /// <summary> Концентрация в удобрении елемента N </summary>
        [JsonProperty("element_N")]
        public Single? Element_N { get; set; }

        /// <summary> Концентрация в удобрении елемента P205 </summary>
        [JsonProperty("element_P2O5")]
        public Single? Element_P2O5 { get; set; }

        /// <summary> Концентрация в удобрении елемента K20 </summary>
        [JsonProperty("element_K2O")]
        public Single? Element_K2O { get; set; }

        /// <summary> Концентрация в удобрении елемента Ca </summary>
        [JsonProperty("element_Ca")]
        public Single? Element_Ca { get; set; }

        /// <summary> Концентрация в удобрении елемента Mg </summary>
        [JsonProperty("element_Mg")]
        public Single? Element_Mg { get; set; }

        /// <summary> Концентрация в удобрении елемента S </summary>
        [JsonProperty("element_S")]
        public Single? Element_S { get; set; }

        /// <summary> Концентрация в удобрении елемента B </summary>
        [JsonProperty("element_B")]
        public Single? Element_B { get; set; }

        /// <summary> Концентрация в удобрении елемента Cl </summary>
        [JsonProperty("element_Cl")]
        public Single? Element_Cl { get; set; }

        /// <summary> Концентрация в удобрении елемента Cu </summary>
        [JsonProperty("element_Cu")]
        public Single? Element_Cu { get; set; }

        /// <summary> Концентрация в удобрении елемента Fe </summary>
        [JsonProperty("element_Fe")]
        public Single? Element_Fe { get; set; }

        /// <summary> Концентрация в удобрении елемента Mn </summary>
        [JsonProperty("element_Mn")]
        public Single? Element_Mn { get; set; }

        /// <summary> Концентрация в удобрении елемента Mo </summary>
        [JsonProperty("element_Mo")]
        public Single? Element_Mo { get; set; }

        /// <summary> Концентрация в удобрении елемента Ni </summary>
        [JsonProperty("element_Ni")]
        public Single? Element_Ni { get; set; }

        /// <summary> Концентрация в удобрении елемента Zn </summary>
        [JsonProperty("element_Zn")]
        public Single? Element_Zn { get; set; }

        /// <summary> units of measurement: 'liter', 'kg' </summary>
        [JsonConverter(typeof(JsonConverter_MeasureUnitOfFertilizer))]
        [JsonProperty("units_of_measurement")]
        public CE_MeasureUnitOfFertilizer UnitsOfMeasurement { get; set; }
        
        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                 ").Append(Id)
                .Append(i).Append("Id_External:        ").Append(Id_External)
                .Append(i).Append("CreatedAt:          ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:          ").Append(UpdatedAt)
                .Append(i).Append("FertilizerType:     ").Append(FertilizerType)
                .Append(i).Append("AdditionalInfo:     ").Append(AdditionalInfo)
                .Append(i).Append("Description:        ").Append(Description)
                .Append(i).Append("Element_N:          ").Append(Element_N.F("0.00"))
                .Append(i).Append("Element_P2O5:       ").Append(Element_P2O5.F("0.00"))
                .Append(i).Append("Element_K2O:        ").Append(Element_K2O.F("0.00"))
                .Append(i).Append("Element_Ca:         ").Append(Element_Ca.F("0.00"))
                .Append(i).Append("Element_Mg:         ").Append(Element_Mg.F("0.00"))
                .Append(i).Append("Element_S:          ").Append(Element_S.F("0.00"))
                .Append(i).Append("Element_B:          ").Append(Element_B.F("0.00"))
                .Append(i).Append("Element_Cl:         ").Append(Element_Cl.F("0.00"))
                .Append(i).Append("Element_Cu:         ").Append(Element_Cu.F("0.00"))
                .Append(i).Append("Element_Fe:         ").Append(Element_Fe.F("0.00"))
                .Append(i).Append("Element_Mn:         ").Append(Element_Mn.F("0.00"))
                .Append(i).Append("Element_Mo:         ").Append(Element_Mo.F("0.00"))
                .Append(i).Append("Element_Ni:         ").Append(Element_Ni.F("0.00"))
                .Append(i).Append("Element_Zn:         ").Append(Element_Zn.F("0.00"))
                .Append(i).Append("UnitsOfMeasurement: ").Append(UnitsOfMeasurement);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
