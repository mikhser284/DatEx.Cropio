using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_AlertType : ICropioRegularObject
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

        /// <summary> name for grouping alert types </summary>
        /// <remarks> In ELMA: String AlertsGroup (Группа тревог) </remarks>
        [JsonProperty("alert_type")]        
        public String AlertType { get; set; }

        /// <summary> name of alert type </summary>
        /// <remarks> In ELMA: String Name (Название) </remarks>
        [JsonProperty("name")]
        public String Name { get; set; }

        /// <summary> priority of created alerts. Could be 'low', 'mid', 'high' </summary>
        /// <remarks> In ELMA: Cropio_AllertPriority Priority (Приоритет) </remarks>
        [JsonProperty("priority")]
        [JsonConverter(typeof(JsonConverter_AllertPriority))]
        public CE_AllertPriority Priority { get; set; }

        /// <summary> Description </summary>
        /// <remarks> In ELMA: String Description (Описание) </remarks>
        [JsonProperty("description")]
        public String Description { get; set; }

        /// <summary> AdditionalInfo </summary>
        /// <remarks> In ELMA: String AdditionalInfo (Дополнительная информация) </remarks>
        [JsonProperty("additional_info")]
        public String AdditionalInfo { get; set; }
        
        /// <summary> boolean. The types of alarms from the archive will not be displayed in the alarm selection lists </summary>
        /// <remarks> In ELMA: Boolean IsArchived (Архивировано) </remarks>
        [JsonProperty("archived")]
        public Boolean IsArchived { get; set; }
                
        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:              ").Append(Id)
                .Append(i).Append("CreatedAt:       ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:       ").Append(UpdatedAt)
                .Append(i).Append("AlertType:       ").Append(AlertType)
                .Append(i).Append("Name:            ").Append(Name)
                .Append(i).Append("Priority:        ").Append(Priority)
                .Append(i).Append("Description:     ").Append(Description)
                .Append(i).Append("AdditionalInfo:  ").Append(AdditionalInfo)
                .Append(i).Append("Archived:        ").Append(IsArchived);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
