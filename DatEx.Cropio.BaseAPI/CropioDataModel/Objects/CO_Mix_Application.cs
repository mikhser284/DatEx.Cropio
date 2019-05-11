using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_Mix_Application : ICropioRegularObject
    {
        //Not tested

        /// <summary> Cropio ID of ApplicationMixItem </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> time when object created </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> last time when object was updated </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary> Cropio ID of AgroOperation </summary>
        [JsonProperty("agro_operation_id")]
        public Int32 Id_AgroOperation { get; set; }

        /// <summary> Cropio ID applicable </summary>
        [JsonProperty("applicable_id")]
        public Int32 Id_Applicable { get; set; }

        /// <summary> Cropio type of applicable: "Seed", "Fertilizer", "Chemical" </summary>
        [JsonProperty("applicable_type")]
        public String ApplicableType { get; set; }

        /// <summary> planned amount of application </summary>
        [JsonProperty("planned_amount")]
        public Single PlannedAmount { get; set; }

        /// <summary> actual amount of application </summary>
        [JsonProperty("fact_amount")]
        public Single FactAmount { get; set; }

        /// <summary> planned rate of application </summary>
        [JsonProperty("planned_rate")]
        public String PlannedRate { get; set; }

        /// <summary> actual rate of application </summary>
        [JsonProperty("fact_rate")]
        public String FactRate { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                  ").Append(Id)
                .Append(i).Append("CreatedAt:           ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:           ").Append(UpdatedAt)
                .Append(i).Append("Id_AgroOperation:    ").Append(Id_AgroOperation)
                .Append(i).Append("Id_Applicable:       ").Append(Id_Applicable)
                .Append(i).Append("ApplicableType:      ").Append(ApplicableType)
                .Append(i).Append("PlannedAmount:       ").Append(PlannedAmount)
                .Append(i).Append("FactAmount:          ").Append(FactAmount)
                .Append(i).Append("PlannedRate:         ").Append(PlannedRate)
                .Append(i).Append("FactRate:            ").Append(FactRate);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
