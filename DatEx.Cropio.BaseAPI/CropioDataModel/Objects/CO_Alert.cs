using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_Alert : ICropioDocumentableObject
    {
        //Not tested

        /// <summary> Cropio ID of Field </summary>
        /// <remarks> In ELMA: Int32 Id_InCropio (Id в Cropio)</remarks>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> Server time when object was created </summary>
        /// <remarks> In ELMA: DateTime CreatedAt (Дата создания)</remarks>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> Server time when object was updated </summary>
        /// <remarks> In ELMA: DateTime? UpdatedAt (Дата обновления)</remarks>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary> ID of AlertType </summary>
        /// <remarks>
        /// In ELMA: Cropio_AlertType AlertType (Тип тревоги)
        /// In ELMA: Int64 Id_AlertType (Id_AlertType)
        /// </remarks>
        [JsonProperty("alert_type_id")]
        public Int32 Id_AlertType { get; set; }
        
        /// <summary> ID of alertable object </summary>
        /// <remarks>
        /// In ELMA: Cropio_Field Field (Поле)
        /// In ELMA: Int32 Id_AlertableObject (Id_AlertableObject)
        /// </remarks>
        [JsonProperty("alertable_id")]
        public Int32 Id_AlertableObject { get; set; }
        
        /// <summary> type of alertable object </summary>
        /// <remarks> In ELMA: — </remarks>
        [JsonProperty("alertable_type")]
        public String AlertableObjectType { get; set; }

        /// <summary> the time of the beginning of the event that led to the occurrence of an alarm </summary>
        /// <remarks> In ELMA: DateTime EventStartTime (Время начала события) </remarks>
        [JsonProperty("event_start_time")]
        public DateTime EventStartTime { get; set; }

        /// <summary> status of alert, could be 'open', 'closed' </summary>
        /// <remarks> In ELMA: Cropio_AllertStatus Status (Статус) </remarks>
        [JsonConverter(typeof(JsonConverter_StatusOfAlert))]
        [JsonProperty("status")]
        public CE_StatusOfAllert Status { get; set; }
        
        /// <summary> Description </summary>
        /// <remarks> In ELMA: String Description (Описание) </remarks>
        [JsonProperty("description")]
        public String Description { get; set; }

        /// <summary> ID of responsible User from Cropio </summary>
        /// <remarks>
        /// In ELMA: Cropio_User ResponsiblePerson (Ответственная особа)
        /// In ELMA: Int64 Id_ResponsiblePerson (Id_ResponsiblePerson)
        /// </remarks>
        [JsonProperty("responsible_person_id")]
        public Int32? Id_ResponsiblePerson { get; set; }

        /// <summary> ID of Cropio User, whom created alert </summary>
        /// <remarks>
        /// In ELMA: Cropio_User CreatedByUser (Создано пользователем)
        /// In ELMA: Int64 Id_CreatedByUser (Id_CreatedByUser)
        /// </remarks>
        [JsonProperty("created_by_user_id")]
        public Int32? Id_CreatedByUser { get; set; }

        /// <summary> time when the event stopped </summary>
        /// <remarks> In ELMA: DateTime? EventStopTime (Время завершения события) </remarks>
        [JsonProperty("event_stop_time")]
        public DateTime? EventStopTime { get; set; }

        /// <summary> time when the event closed </summary>
        /// <remarks> In ELMA: DateTime? AlertClosedAt (Время закрытия тревоги) </remarks>
        [JsonProperty("alert_closed_at")]
        public DateTime? AlertClosedAt { get; set; }
        
        /// <summary> ID of AutomaticAlert </summary>
        /// <remarks> In ELMA: — </remarks>
        [JsonProperty("automatic_alert_id")]
        public Int32? Id_AutomaticAlert { get; set; }

        /// <summary>  </summary>
        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                   ").Append(Id)
                .Append(i).Append("CreatedAt:            ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:            ").Append(UpdatedAt)
                .Append(i).Append("Id_AlertType:         ").Append(Id_AlertType)
                .Append(i).Append("Id_AlertableObject:   ").Append(Id_AlertableObject)
                .Append(i).Append("AlertableObjectType:  ").Append(AlertableObjectType)
                .Append(i).Append("EventStartTime:       ").Append(EventStartTime)
                .Append(i).Append("Status:               ").Append(Status)
                .Append(i).Append("Description:          ").Append(Description)
                .Append(i).Append("Id_ResponsiblePerson: ").Append(Id_ResponsiblePerson)
                .Append(i).Append("Id_CreatedByUser:     ").Append(Id_CreatedByUser)
                .Append(i).Append("EventStopTime:        ").Append(EventStopTime)
                .Append(i).Append("AlertClosedAt:        ").Append(AlertClosedAt)
                .Append(i).Append("Id_AutomaticAlert:    ").Append(Id_AutomaticAlert);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
