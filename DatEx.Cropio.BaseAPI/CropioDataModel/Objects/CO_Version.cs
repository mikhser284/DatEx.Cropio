using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_Version : ICropioObject
    {
        //Not tested

        /// <summary> Cropio ID of Version. </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> Time when Version record was created </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> Object type </summary>
        [JsonProperty("item_type")]
        public String ItemType { get; set; }

        /// <summary> Object ID </summary>
        [JsonProperty("item_id")]
        public String Id_Item { get; set; }

        /// <summary> Event type (one of: [create], [update], [destroy]). </summary>
        [JsonProperty("event")]
        public String EventType { get; set; }

        /// <summary> User ID who made this change (could be null in case of system-generated changes) </summary>
        [JsonProperty("whodunnit")]
        public String Id_User { get; set; }

        /// <summary> Snapshot of changed Object (before changes apply) in JSON </summary>
        [JsonProperty("snapshot_before_change")]
        [JsonConverter(typeof(JsonAsStringConverter))]
        public String SnapshotBeforeChange { get; set; }

        /// <summary> List of changed attribtues of Object in JSON </summary>
        [JsonProperty("object_changes")]
        [JsonConverter(typeof(JsonAsStringConverter))]
        public String ObjectChanges { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                   ").Append(Id)
                .Append(i).Append("CreatedAt:            ").Append(CreatedAt)
                .Append(i).Append("ItemType:             ").Append(ItemType)
                .Append(i).Append("Id_Item:              ").Append(Id_Item)
                .Append(i).Append("EventType:            ").Append(EventType)
                .Append(i).Append("Id_User:              ").Append(Id_User)
                .Append(i).Append("SnapshotBeforeChange: ").Append(SnapshotBeforeChange)
                .Append(i).Append("ObjectChanges:        ").Append(ObjectChanges);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }

    public class JsonAsStringConverter : JsonConverter
    {
        public override Boolean CanConvert(Type objectType)
        {
            return objectType == typeof(String);
        }

        public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
        {
            if(reader.TokenType == JsonToken.Null) return String.Empty;

            JObject obj = JObject.Load(reader);
            return obj.ToString();
        }

        public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
