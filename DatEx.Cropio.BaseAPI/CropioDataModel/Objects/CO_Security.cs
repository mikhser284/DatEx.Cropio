using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_Security : ICropioRegularObject
    {
        //Not implemented

        [JsonProperty("id")]
        public Int32 Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:                          ").Append(Id)
                .Append(i).Append("CreatedAt:                   ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:                   ").Append(UpdatedAt);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
