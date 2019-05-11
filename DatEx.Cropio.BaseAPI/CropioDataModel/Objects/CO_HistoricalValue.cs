using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatEx.Cropio.BaseAPI
{
    [JsonObject(Title = "data")]
    public class CO_HistoricalValue : ICropioRegularObject
    {
        //Not implemented — Отличный от других объектов формат запросов (какая прелесть !) :(

        //Query params and meta
        //You can pass next params to this resource:
        //field_id - Cropio ID of field. Required!
        //type - type of value: 'temperature', 'ndvi', 'soil_measure'. Required!
        //from_time - begining of time range. Default is 24 hours ago.
        //    to_time - end of time range. Default is current time.
        //    Example:
        //https://cropio.com/api/v3/historical_values?field_id=17323&type=ndvi&from_time=2012-01-01&to_time=2012-12-31
        //The 'meta' block in this resource deffers from typical 'meta' in other resources.
        //{
        //    "request": {
        //        "field_id": "17323",
        //        "type": "ndvi",
        //        "from_time": "2012-01-01T00:00:00.000+00:00",
        //        "to_time": "2012-12-31T00:00:00.000+00:00",
        //        "server_time": "2015-04-24T10:59:21.171+03:00"
        //    },
        //    "response": {
        //        "from_time": "2012-01-01T00:00:00.000+00:00",
        //        "to_time": "2012-12-31T00:00:00.000+00:00",
        //        "obtained_records": 0
        //    }
        //}


        /// <summary> Cropio ID of HistoricalValue </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary> time when object created on server </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> last time when object was updated on server </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary> Cropio ID of related field </summary>
        [JsonProperty("field_id")]
        public Int32 Id_Field { get; set; }

        /// <summary> year </summary>
        [JsonProperty("year")]
        public Int32 Year { get; set; }

        /// <summary> type of product ('temperature', 'ndvi', 'soil_measure') </summary>
        [JsonProperty("product_type")]
        public String ProductType { get; set; }

        /// <summary> </summary>
        [JsonProperty("value")]
        public List<Tuple<DateTime, List<Single>>> Values { get; set; }

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
