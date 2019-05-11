using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_WorkRecord : ICropioRegularObject
    {
        //Not tested

        /// <summary> Cropio ID of WorkRecord </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> Server time when object was created </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> Server time when object was updated </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary> User ID </summary>
        [JsonProperty("user_id")]
        public Int32 Id_User { get; set; }

        /// <summary> Start time of work </summary>
        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        /// <summary> End time of work </summary>
        [JsonProperty("end_time")]
        public DateTime? EndTime { get; set; }

        /// <summary> Work type (one of: dispatcher) </summary>
        [JsonProperty("work_type")]
        public String WorkType { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                          ").Append(Id)
                .Append(i).Append("CreatedAt:                   ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:                   ").Append(UpdatedAt)
                .Append(i).Append("Id_User:                   ").Append(Id_User)
                .Append(i).Append("StartTime:                   ").Append(StartTime)
                .Append(i).Append("EndTime:                   ").Append(EndTime)
                .Append(i).Append("WorkType:                   ").Append(WorkType);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
