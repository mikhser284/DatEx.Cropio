using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    public class CropioServerResponse
    {
        [JsonProperty("status")] public String Result_Status { get; set; }

        [JsonProperty("error")] public String Result_Error { get; set; }

        [JsonProperty("message")] public String Result_Message { get; set; }
    }

    public interface ICropioServerResponse
    {
        CropioResponse CropioResponse { get; set; }
    }

    public class CropioResponse
    {
        public Boolean IsSuccess { get; }

        public HttpStatusCode Status { get; }

        public String RessonPhrase { get; }

        public CropioResponse(HttpResponseMessage responseMessage)
        {
            IsSuccess = responseMessage.IsSuccessStatusCode;
            Status = responseMessage.StatusCode;
            RessonPhrase = String.Format("{0} ({1})", (Int32)responseMessage.StatusCode, responseMessage.ReasonPhrase);
        }

        public String ToString(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("IsSuccess:     ").Append(IsSuccess)
                .Append(i).Append("Status:        ").Append(Status)
                .Append(i).Append("RessonPhrase:  ").AppendLine(RessonPhrase);
            
            return sb.ToString();
        }

        public override String ToString()
        {
            return ToString(0);
        }
    }
}
