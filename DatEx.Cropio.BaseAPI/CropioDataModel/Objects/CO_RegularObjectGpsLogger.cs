using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [Obsolete("Не удалось подобрать соответствие названию таблицы БД (ошибка 500)")]
    [JsonObject(Title = "data")]
    public class CO_RegularObjectGpsLogger : ICropioRegularObject
    {
        //Not tested

        /// <summary> Cropio ID of DataSourceGpsLogger </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> time when object created </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> last time when object was updated </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary> mappable odject id (for example machine_id) </summary>
        [JsonProperty("mappable_id")]
        public Int32 Id_Mappable { get; set; }

        /// <summary> mappable odject type (for example 'Machine') </summary>
        [JsonProperty("mappable_type")]
        public String MappableType { get; set; }

        /// <summary> id of gps logger </summary>
        [JsonProperty("gps_logger_id")]
        public Int32 Id_GpsLogger { get; set; }

        /// <summary> start time when we take data from logger for machine </summary>
        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        /// <summary> end time, can be nil </summary>
        [JsonProperty("end_time")]
        public DateTime? EndTime { get; set; }

        /// <summary> some additional info from users </summary>
        [JsonProperty("additional_info")]
        public String AdditionalInfo { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:              ").Append(Id)
                .Append(i).Append("CreatedAt:       ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:       ").Append(UpdatedAt)
                .Append(i).Append("Id_Mappable:     ").Append(Id_Mappable)
                .Append(i).Append("MappableType:    ").Append(MappableType)
                .Append(i).Append("Id_GpsLogger:    ").Append(Id_GpsLogger)
                .Append(i).Append("StartTime:       ").Append(StartTime)
                .Append(i).Append("EndTime:         ").Append(EndTime)
                .Append(i).Append("AdditionalInfo:  ").Append(AdditionalInfo);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
