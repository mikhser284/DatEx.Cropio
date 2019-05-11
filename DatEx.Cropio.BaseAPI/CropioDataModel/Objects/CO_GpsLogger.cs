using Newtonsoft.Json;
using System;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_GpsLogger : ICropioRegularObject
    {
        //Not tested

        /// <summary> Cropio ID of GpsLogger </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> time when object created on server </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> last time when object was updated </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary> gps logger type </summary>
        [JsonProperty("logger_type")]
        public String LoggerType { get; set; }
        
        /// <summary> device imei or unique id </summary>
        [JsonProperty("imei")]
        public String Imei { get; set; }
        
        /// <summary> sim phone number in device </summary>
        [JsonProperty("phone_number")]
        public String PhoneNumber { get; set; }
        
        /// <summary> device serial number </summary>
        [JsonProperty("serial_number")]
        public String SerialNumber { get; set; }
        
        /// <summary> some description </summary>
        [JsonProperty("description")]
        public String Description { get; set; }

        public String GetTextView(Int32 indentLevel)
        {
            String i = HttpClientHelper.Indent(indentLevel);
            StringBuilder sb = new StringBuilder()
                .Append(i).Append("Id:              ").Append(Id)
                .Append(i).Append("CreatedAt:       ").Append(CreatedAt)
                .Append(i).Append("UpdatedAt:       ").Append(UpdatedAt)
                .Append(i).Append("LoggerType:      ").Append(LoggerType)
                .Append(i).Append("Imei:            ").Append(Imei)
                .Append(i).Append("PhoneNumber:     ").Append(PhoneNumber)
                .Append(i).Append("SerialNumber:    ").Append(SerialNumber)
                .Append(i).Append("Description:     ").Append(Description);
            return sb.ToString();
        }

        public override String ToString()
        {
            return GetTextView(0);
        }
    }
}
