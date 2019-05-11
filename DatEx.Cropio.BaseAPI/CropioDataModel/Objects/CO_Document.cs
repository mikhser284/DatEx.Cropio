using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_Document : ICropioRegularObject
    {
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("documentable_id")]
        public int DocumentableObjId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("document_url")]
        public string DocumentUrl { get; set; }

        [JsonProperty("documentable_type")]
        public string DocumentableObjType { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                  ").Append(Id)
                .Append(i).Append("CreatedAt:           ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:           ").Append(UpdatedAt)
                .Append(i).Append("Name:                ").Append(Name)
                .Append(i).Append("DocumentableObjId:   ").Append(DocumentableObjId)
                .Append(i).Append("Description:         ").Append(Description)
                .Append(i).Append("DocumentUrl:         ").Append(DocumentUrl)
                .Append(i).Append("DocumentableObjType: ").Append(DocumentableObjType);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }

}
