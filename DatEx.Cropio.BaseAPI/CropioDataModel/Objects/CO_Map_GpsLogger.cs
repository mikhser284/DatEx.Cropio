using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [Obsolete("Не удалось подобрать соответствие названию таблицы БД (ошибка 500)")]
    [JsonObject(Title = "data")]
    public class CO_Map_GpsLogger : ICropioRegularObject
    {
        //Not tested

        /// <summary> Cropio ID of GpsLoggerMappingItem </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> time when object created on server </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> last time when object was updated </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary> id of gps_logger </summary>
        [JsonProperty("gps_logger_id")]
        public Int32 Id_GgpsLogger { get; set; }

        /// <summary> id of mappable object (for example machine_id) </summary>
        [JsonProperty("mappable_id")]
        public Int32 Id_Mappable { get; set; }

        /// <summary> type of mappable object (for example "Machine") </summary>
        [JsonProperty("mappable_type")]
        public String MappableType { get; set; }

        /// <summary> start time when logger was installed on mappable object </summary>
        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        /// <summary> expiration date for installed logger (can be nil) </summary>
        [JsonProperty("end_time")]
        public DateTime? EndTime { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:              ").Append(Id)
                .Append(i).Append("CreatedAt:       ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:       ").Append(UpdatedAt)
                .Append(i).Append("Id_GgpsLogger:   ").Append(Id_GgpsLogger)
                .Append(i).Append("Id_Mappable:     ").Append(Id_Mappable)
                .Append(i).Append("MappableType:    ").Append(MappableType)
                .Append(i).Append("StartTime:       ").Append(StartTime)
                .Append(i).Append("EndTime:         ").Append(EndTime);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
