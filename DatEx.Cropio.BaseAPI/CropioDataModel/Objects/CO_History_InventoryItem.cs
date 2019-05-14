using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_History_InventoryItem : ICropioExtendetObject
    {
        //Not tested

        /// <summary> Cropio ID of Field </summary>
        /// <remarks> In ELMA: Int32 Id_InCropio (Id в Cropio)</remarks>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary>  </summary>
        /// <remarks> In ELMA: Guid Uid (Уникальный идентификатор) </remarks>
        [JsonProperty("external_id")]
        public String Id_External { get; set; }

        /// <summary> Server time when object was created </summary>
        /// <remarks> In ELMA: DateTime CreatedAt (Дата создания)</remarks>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> Server time when object was updated </summary>
        /// <remarks> In ELMA: DateTime? UpdatedAt (Дата обновления)</remarks>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary> id of historyable object (machine_id, field_id, etc.) </summary>
        /// <remarks>
        /// In ELMA: Cropio_Field Field (Поле) 
        /// In ELMA: Int64 Id_Historyable (Id_Historyable)
        /// </remarks>
        [JsonProperty("historyable_id")]
        public Int32 Id_Historyable { get; set; }
        
        [JsonConverter(typeof(JsonConverter_HistoryableType))]
        /// <summary> type of record: 'Machine', 'Implement', 'Field' </summary>
        /// <remarks> In ELMA: — </remarks>
        [JsonProperty("historyable_type")]
        public CE_HistoryableType HistoryableType { get; set; }

        /// <summary> date when record comes into effect </summary>
        /// <remarks> In ELMA: DateTime RecordComesIntoEffectAt (Время когда запись вступает в силу) </remarks>
        [JsonProperty("event_start_at")]
        public DateTime RecordComesIntoEffectAt { get; set; }

        /// <summary>
        /// • if object is available: 'bought', 'taken_on_lease_start', 'granted_on_lease_end', 'temporaly_unavailable_end', 'other_available_reason'
        /// • if object is unavailable: 'sold', 'taken_on_lease_end', 'granted_on_lease_start', 'temporaly_unavailable_start', 'other_unavailable_reason'
        /// </summary>
        /// <remarks> In ELMA: — </remarks>
        [JsonProperty("reason")]
        public String Reason { get; set; }

        /// <summary> description </summary>
        /// <remarks> In ELMA: String Description (Описание) </remarks>
        [JsonProperty("description")]
        public String Description { get; set; }

        /// <summary> boolean, is record is active </summary>
        /// <remarks> In ELMA: Boolean IsAvailable (Доступно) </remarks>
        [JsonProperty("available")]
        public Boolean IsAvailable { get; set; }

        /// <summary> boolean, hide object in reports and views </summary>
        /// <remarks> In ELMA: Boolean IsHidden (Скрыто) </remarks>
        [JsonProperty("hidden")]
        public Boolean IsHidden { get; set; }
        
        /// <summary> end date for record, calculates automatically by Cropio if there are new records for historyable object </summary>
        /// <remarks> In ELMA: DateTime? RecordComesOutOfEffectAt (Время когда запись утрачивает силу) </remarks>
        [JsonProperty("event_end_at")]
        public DateTime? RecordComesOutOfEffectAt { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                       ").Append(Id)
                .Append(i).Append("CreatedAt:                ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:                ").Append(UpdatedAt)
                .Append(i).Append("Id_External:              ").Append(Id_External)
                .Append(i).Append("Id_Historyable:           ").Append(Id_Historyable)
                .Append(i).Append("HistoryableType:          ").Append(HistoryableType)
                .Append(i).Append("RecordComesIntoEffectAt:  ").Append(RecordComesIntoEffectAt)
                .Append(i).Append("Reason:                   ").Append(Reason)
                .Append(i).Append("Description:              ").Append(Description)
                .Append(i).Append("Available:                ").Append(IsAvailable)
                .Append(i).Append("Hidden:                   ").Append(IsHidden)
                .Append(i).Append("RecordComesOutOfEffectAt: ").Append(RecordComesOutOfEffectAt);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
