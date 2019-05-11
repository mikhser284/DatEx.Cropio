using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Интервал времени </summary>
    public class TimeInverval
    {
        /// <summary> Начальное время </summary>
        public DateTime Begin { get; set; }

        /// <summary> Конечное время </summary>
        public DateTime End { get; set; }

        /// <summary> Продолжительность </summary>
        public TimeSpan Duration { get { return End - Begin; } }

        public TimeInverval(DateTime begin, DateTime end)
        {
            Begin = begin;
            End = end;
        }

        public override string ToString()
        {
            return String.Format("{0:yyyy.MM.dd HH:mm:ss} — {1:yyyy.MM.dd HH:mm:ss}", Begin, End);
        }
    }

    public class JsonConverter_TimeInverval : JsonConverter<IEnumerable<TimeInverval>>
    {
        public override void WriteJson(JsonWriter writer, IEnumerable<TimeInverval> value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<TimeInverval> ReadJson(JsonReader reader, Type objectType, IEnumerable<TimeInverval> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            List<TimeInverval> collection = new List<TimeInverval>();

            switch(token.Type)
            {
                case JTokenType.Null:
                {
                    return collection;
                }
                case JTokenType.Array:
                {
                    for(int i = 0; i < token.Count(); i++)
                    {
                        DateTime begin = token[i][0].Value<DateTime>();
                        DateTime end = token[i][1].Value<DateTime>();
                        //
                        collection.Add(new TimeInverval(begin, end));
                    }
                    return collection;
                }
                default:
                {
                    throw new NotImplementedException(String.Format("{0}{1}", typeof(JsonConverter_TimeInverval).Name, nameof(ReadJson)));
                }
            }
        }
    }
}
