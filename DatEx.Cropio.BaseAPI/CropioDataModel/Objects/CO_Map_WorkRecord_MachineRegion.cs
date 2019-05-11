using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_Map_WorkRecord_MachineRegion : ICropioRegularObject
    {
        //Not tested

        /// <summary> Cropio ID of WorkRecordMachineRegionMappingItem </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> Server time when object was created </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> Server time when object was updated </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary> WorkRecord ID </summary>
        [JsonProperty("work_record_id")]
        public Int32 Id_WorkRecord { get; set; }

        /// <summary> MachineRegion ID </summary>
        [JsonProperty("machine_region_id")]
        public Int32 Id_MachineRegion { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:               ").Append(Id)
                .Append(i).Append("CreatedAt:        ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:        ").Append(UpdatedAt)
                .Append(i).Append("Id_WorkRecord:    ").Append(Id_WorkRecord)
                .Append(i).Append("Id_MachineRegion: ").Append(Id_MachineRegion);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
