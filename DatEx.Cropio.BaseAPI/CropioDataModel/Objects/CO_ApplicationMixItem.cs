using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Внесения (семян, удобрений, химикатов, ...) </summary>
    /// <remarks>
    /// Пример json-объекта находится в JsonSamples/application_mix_items.json
    /// 
    /// Связи:
    /// @ Id
    /// @ Id_External
    /// - Id_AgroOperation              (agro_operations.i в json)
    /// - Id_Applicable                 (seeds.id; fertilizers.i или chemicals.id;  в json)
    /// </remarks>
    [JsonObject(Title = "application_mix_items")]
    public class CO_ApplicationMixItem : ICropioExtendetObject
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

        /// <summary> Id связанного объекта "Агрооперация" (agro_operations.id в json) </summary>
        [JsonProperty("agro_operation_id")]
        public Int32 Id_AgroOperation { get; set; }

        /// <summary> Id связанного объекта (в зависимости от значения ApplicableType: CO_Seed, CO_Fertilizer или CO_Chemical) (seeds.id; fertilizers.i или chemicals.id в json) </summary>
        [JsonProperty("applicable_id")]
        public Int32 Id_Applicable { get; set; }

        /// <summary> Тип связанного объекта (одно из следующих значений: "Seed", "Fertilizer", "Chemical") </summary>
        [JsonConverter(typeof(JsonConverter_TypeOfApplicable))]
        [JsonProperty("applicable_type")]
        public CE_TypeOfApplicable ApplicableType { get; set; }

        //TODO В каких ед. измерения?
        /// <summary> Актуальный объем внесенного вещества (ед. изм ?) </summary>
        [JsonProperty("fact_amount")]
        public Single? FactAmount { get; set; }

        //TODO В каких ед. измерения?
        /// <summary> Актуальный темп внесения вещества (ед. изм ?) </summary>
        [JsonProperty("fact_rate")]
        public Single? FactRate { get; set; }

        //TODO В каких ед. измерения?
        /// <summary> Планируемый объем внесенного вещеста (ед. изм. ?) </summary>
        [JsonProperty("planned_amount")]
        public Single? PlannedAmount { get; set; }

        //TODO В каких ед. измерения?
        /// <summary> Планируемый темп внесения вещества (ед. изм. ?) </summary>
        [JsonProperty("planned_rate")]
        public Single? PlannedRate { get; set; }
        
        /// <summary> Планируемое значение (ед. изм. ?) </summary>
        [JsonProperty("planned_value")]
        public Single? PlannedValue { get; set; }

        /// <summary> Значение (ед. изм ?) </summary>
        [JsonProperty("value")]
        public Single? Value { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:               ").Append(Id)
                .Append(i).Append("Id_Eexternal:     ").Append(Id_External)
                .Append(i).Append("CreatedAt:        ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:        ").Append(UpdatedAt)
                .Append(i).Append("Id_AgroOperation: ").Append(Id_AgroOperation)
                .Append(i).Append("Id_Applicable:    ").Append(Id_Applicable)
                .Append(i).Append("ApplicableType:   ").Append(ApplicableType)
                .Append(i).Append("FactAmount:       ").Append(FactAmount.F("0.00"))
                .Append(i).Append("FactRate:         ").Append(FactRate.F("0.00"))
                .Append(i).Append("PlannedAmount:    ").Append(PlannedAmount.F("0.00"))
                .Append(i).Append("PlannedRate:      ").Append(PlannedRate.F("0.00"))
                .Append(i).Append("PlannedValue:     ").Append(PlannedValue.F("0.00"))
                .Append(i).Append("Value:            ").Append(Value.F("0.00"));
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
