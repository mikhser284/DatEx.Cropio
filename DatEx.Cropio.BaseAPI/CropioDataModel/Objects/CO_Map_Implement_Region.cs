using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_Map_Implement_Region : ICropioRegularObject
    {
        //Not tested

        /// <summary> Cropio ID of ImplementRegionMappingItem </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> time when object created on server </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>  last time when object was updated </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary> ID of Implement </summary>
        [JsonProperty("implement_id")]
        public Int32 Id_Implement { get; set; }

        /// <summary> ID of MachineRegion </summary>
        [JsonProperty("machine_region_id")]
        public Int32 Id_MachineRegion { get; set; }

        /// <summary> start date of mapping </summary>
        [JsonProperty("date_start")]
        public DateTime DateStart { get; set; }

        /// <summary>   </summary>
        [JsonProperty("date_end")]
        public DateTime? DateEnd { get; set; }

        /// <summary> boolean, true if there no end date of mapping </summary>
        [JsonProperty("no_date_end")]
        public Boolean NoDateEnd { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                  ").Append(Id)
                .Append(i).Append("CreatedAt:           ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:           ").Append(UpdatedAt)
                .Append(i).Append("Id_Implement:        ").Append(Id_Implement)
                .Append(i).Append("Id_MachineRegion:    ").Append(Id_MachineRegion)
                .Append(i).Append("DateStart:           ").Append(DateStart)
                .Append(i).Append("DateEnd:             ").Append(DateEnd)
                .Append(i).Append("NoDateEnd:           ").Append(NoDateEnd);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
