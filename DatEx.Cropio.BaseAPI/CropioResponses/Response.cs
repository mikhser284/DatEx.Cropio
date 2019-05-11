using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    public class Response<T> : ICropioServerResponse where T : ICropioObject
    {
        [JsonIgnore]
        public CropioResponse CropioResponse { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        public String ToString(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            String i2 = HttpClientHelper.Indent(indentLevel + 1);
            StringBuilder sb = new StringBuilder()
                  .Append(i).Append("CropioResponse: ").Append(CropioResponse.ToString(indentLevel + 1));
            if(Data != null)
                sb.Append(i).Append("Data:           ").Append(Data.GetTextView(indentLevel + 1));
            return sb.ToString();
        }

        public override String ToString()
        {
            return ToString(0);
        }
    }
}
