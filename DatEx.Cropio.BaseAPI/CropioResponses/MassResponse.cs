using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    //    [JsonObject(Title = "MassResponse")]
    public class MassResponse<T> : ICropioServerResponse
    {
        public CropioResponse CropioResponse { get; set; }

        [JsonProperty("data")]
        public List<T> Data { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        public String ToString(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("CropioResponse:  ").Append(CropioResponse.ToString(indentLevel + 1));
            sb.AppendLine();
            if(Data != null) sb.Append(i).Append("Data: ").Append(String.Join(", ", Data));
            if(Meta != null) sb.Append(i).Append("Meta: ").Append(Meta.ToString(indentLevel + 1));
            return sb.ToString();
        }

        public override String ToString()
        {
            return ToString(0);
        }
    }

    [JsonObject(Title = "Meta")]
    public class Meta
    {
        [JsonProperty("request")]
        public Request Request { get; set; }

        [JsonProperty("response")]
        public Response Response { get; set; }

        public String ToString(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Request:  ").Append(Request.ToString(indentLevel + 1))
                .Append(i).Append("Response: ").Append(Response.ToString(indentLevel + 1));
            return sb.ToString();
        }

        public override String ToString()
        {
            return ToString(0);
        }
    }

    [JsonObject(Title = "Request")]
    public class Request
    {
        [JsonProperty("from_id")]
        public Int32? FromId { get; set; }

        [JsonProperty("limit")]
        public Int32? Limit { get; set; }

        [JsonProperty("server_time")]
        public DateTime ServerTime { get; set; }

        public String ToString(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("FromId:      ").Append(FromId)
                .Append(i).Append("Limit:       ").Append(Limit)
                .Append(i).Append("ServerTime:  ").Append(ServerTime);
            return sb.ToString();
        }

        public override String ToString()
        {
            return ToString(0);
        }
    }

    [JsonObject(Title = "Response")]
    public class Response
    {
        [JsonProperty("limit")]
        public Int32? Limit { get; set; }

        [JsonProperty("obtained_records")]
        public Int32 ObtainedRecords { get; set; }

        [JsonProperty("first_record_id")]
        public Int32? FirstRecordId { get; set; }

        [JsonProperty("last_record_id")]
        public Int32? LastRecordId { get; set; }        

        public String ToString(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Limit:           ").Append(Limit)
                .Append(i).Append("ObtainedRecords: ").Append(ObtainedRecords)
                .Append(i).Append("FirstRecordId:   ").Append(FirstRecordId)
                .Append(i).Append("LastRecordId:    ").Append(LastRecordId);
            return sb.ToString();
        }

        public override String ToString()
        {
            return ToString(0);
        }
    }

}
