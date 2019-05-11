using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_AutomaticAlert : ICropioRegularObject
    {
        //Not tested

        [JsonProperty("id")]
        public Int32 Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("alert_type_id")]
        public Int32 Id_AlertType { get; set; }

        [JsonProperty("automatic_alert_type")]
        public String AutomaticAlertType { get; set; }

        [JsonProperty("automatic_alert_subtype")]
        public String AutomaticAlertSubtype { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("active")]
        public Boolean Active { get; set; }
        
        [JsonProperty("description")]
        public String Description { get; set; }
        
        [JsonProperty("alert_settings")]
        public String AlertSettings { get; set; }

        [JsonProperty("scheduled")]
        public Boolean Scheduled { get; set; }

        [JsonProperty("schedule_start_time")]
        public DateTime? ScheduleStartTime { get; set; }

        [JsonProperty("schedule_end_time")]
        public DateTime? ScheduleEndTime { get; set; }

        [JsonProperty("time_zone")]
        public String TimeZone { get; set; }


        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                      ").Append(Id)
                .Append(i).Append("CreatedAt:               ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:               ").Append(UpdatedAt)
                .Append(i).Append("Id_AlertType:            ").Append(Id_AlertType)
                .Append(i).Append("AutomaticAlertType:      ").Append(AutomaticAlertType)
                .Append(i).Append("AutomaticAlertSubtype:   ").Append(AutomaticAlertSubtype)
                .Append(i).Append("Name:                    ").Append(Name)
                .Append(i).Append("IsActive:                  ").Append(Active)
                .Append(i).Append("Description:             ").Append(Description)
                .Append(i).Append("AlertSettings:           ").Append(AlertSettings)
                .Append(i).Append("Scheduled:               ").Append(Scheduled)
                .Append(i).Append("ScheduleStartTime:       ").Append(ScheduleStartTime)
                .Append(i).Append("ScheduleEndTime:         ").Append(ScheduleEndTime);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
