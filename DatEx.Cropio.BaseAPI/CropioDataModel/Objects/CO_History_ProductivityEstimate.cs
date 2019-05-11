using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_History_ProductivityEstimate : ICropioRegularObject
    {
        //Not implemented

        /// <summary> Cropio ID of ProductivityEstimate </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> Time when object created on server </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> Last time when object was updated </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary> Field ID </summary>
        [JsonProperty("field_id")]
        public Int32 Id_Field { get; set; }
        
        /// <summary> Year </summary>
        [JsonProperty("year")]
        public Int32 Year { get; set; }
        
        /// <summary> History of ProductivityEstimation (JSON) </summary>
        [JsonProperty("estimate_history")]
        public String EstimateHistory { get; set; }


        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:              ").Append(Id)
                .Append(i).Append("CreatedAt:       ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:       ").Append(UpdatedAt)
                .Append(i).Append("Id_Field:        ").Append(Id_Field)
                .Append(i).Append("Year:            ").Append(Year)
                .Append(i).Append("EstimateHistory: ").Append(EstimateHistory);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
