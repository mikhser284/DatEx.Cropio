using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    public class MassResponse_Changes : ICropioServerResponse
    {
        public CropioResponse CropioResponse { get; set; }

        [JsonProperty("data")]
        public List<Data_Changes> Data { get; set; }

        [JsonProperty("meta")]
        public Meta_Changes Meta { get; set; }

        public String ToString(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            String i2 = HttpClientHelper.Indent(indentLevel + 1);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("CropioResponse:  ").Append(CropioResponse.ToString(indentLevel + 1));
            if (Data != null)
            {
                sb.Append(i).Append("Data: ");
                Int32 itemNumber = 0;
                foreach (Data_Changes item in Data)
                {
                    sb  .Append(i2).Append("──────────── ").Append(itemNumber++)
                        .Append(item.ToString(indentLevel + 1));
                }
            }
            if(Meta != null)
                sb.Append(i).Append("Meta: ").Append(Meta.ToString(indentLevel + 1));
            return sb.ToString();
        }

        public override String ToString()
        {
            return ToString(0);
        }
    }

    [JsonObject(Title = "data")]
    public class Data_Changes
    {
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public String ToString(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:          ").Append(Id)
                .Append(i).Append("UpdatedAt:   ").Append(UpdatedAt);
            return sb.ToString();
        }

        public override String ToString()
        {
            return ToString(0);
        }
    }

    [JsonObject(Title = "meta")]
    public class Meta_Changes
    {
        [JsonProperty("request")]
        public ChangesRequest Request { get; set; }

        [JsonProperty("response")]
        public ChangesResponse Response { get; set; }

        public String ToString(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Request:     ").Append(Request.ToString(indentLevel + 1))
                .Append(i).Append("Response:    ").Append(Response.ToString(indentLevel + 1));
            return sb.ToString();
        }

        public override String ToString()
        {
            return ToString(0);
        }
    }

    [JsonObject(Title = "request")]
    public class ChangesRequest
    {
        [JsonProperty("from_time")]
        public DateTime FromTime { get; set; }

        [JsonProperty("to_time")]
        public DateTime ToTime { get; set; }

        [JsonProperty("server_time")]
        public DateTime ServerTime { get; set; }

        public String ToString(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("FromTime:        ").Append(FromTime)
                .Append(i).Append("ToTime:          ").Append(ToTime)
                .Append(i).Append("ServerTime:      ").Append(ServerTime);
            return sb.ToString();
        }

        public override String ToString()
        {
            return ToString(0);
        }
    }

    [JsonObject(Title = "response")]
    public class ChangesResponse
    {
        [JsonProperty("obtained_records")]
        public Int32 ObtainedRecords { get; set; }

        [JsonProperty("first_record_time")]
        public DateTime? FirstRecordTime { get; set; }

        [JsonProperty("last_record_time")]
        public DateTime? LastRecordTime { get; set; }

        public String ToString(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("ObtainedRecords: ").Append(ObtainedRecords)
                .Append(i).Append("FirstRecordTime: ").Append(FirstRecordTime)
                .Append(i).Append("LastRecordTime:  ").Append(LastRecordTime);
            return sb.ToString();
        }

        public override String ToString()
        {
            return ToString(0);
        }
    }


}
