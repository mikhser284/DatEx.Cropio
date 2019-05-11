using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_Mix_AgriWorkPlan_Application : ICropioRegularObject
    {
        //Not tested

        /// <summary> Cropio ID of AgriWorkApplicationMixItem </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> time when object created </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> last time when object was updated </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary> Cropio ID of related AgriWorkPlan </summary>
        [JsonProperty("agri_work_plan_id")]
        public Int32 Id_AgriWorkPlan { get; set; }
        
        /// <summary> Cropio type of applicable object ('Seed', 'Fertilizer', 'Chemical') </summary>
        [JsonProperty("applicable_type")]
        public String ApplicableType { get; set; }
        
        /// <summary> Cropio ID of applicable object </summary>
        [JsonProperty("applicable_id")]
        public Int32 Id_Applicable { get; set; }
        
        /// <summary> amount of application </summary>
        [JsonProperty("amount")]
        public Single Amount { get; set; }
        
        /// <summary> your system information </summary>
        [JsonProperty("additional_info")]
        public String AdditionalInfo { get; set; }
        
        /// <summary> rate of application </summary>
        [JsonProperty("rate")]
        public Single Rate { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:              ").Append(Id)
                .Append(i).Append("CreatedAt:       ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:       ").Append(UpdatedAt)
                .Append(i).Append("Id_AgriWorkPlan: ").Append(Id_AgriWorkPlan)
                .Append(i).Append("ApplicableType:  ").Append(ApplicableType)
                .Append(i).Append("Id_Applicable:   ").Append(Id_Applicable)
                .Append(i).Append("Amount:          ").Append(Amount)
                .Append(i).Append("AdditionalInfo:  ").Append(AdditionalInfo)
                .Append(i).Append("Rate:            ").Append(Rate);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
