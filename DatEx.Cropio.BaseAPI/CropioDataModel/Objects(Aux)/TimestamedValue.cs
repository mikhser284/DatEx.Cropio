using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Значение с отметкой времени </summary>
    public class TimestamedValue<T>
    {
        /// <summary> Время </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary> Значение </summary>
        public T Value { get; set; }

        public TimestamedValue(DateTime timeStamp, T value)
        {
            TimeStamp = timeStamp;
            Value = value;
        }

        public override string ToString()
        {
            return String.Format("{0:yyyy.MM.dd в HH:mm:ss} — {1}", TimeStamp, Value);
        }
    }

    public class JsonConverter_TimestampedValue<T> : JsonConverter<IEnumerable<TimestamedValue<T>>>
    {
        public override void WriteJson(JsonWriter writer, IEnumerable<TimestamedValue<T>> value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<TimestamedValue<T>> ReadJson(JsonReader reader, Type objectType, IEnumerable<TimestamedValue<T>> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            List<TimestamedValue<T>> collection = new List<TimestamedValue<T>>();

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
                        DateTime timeStamp = token[i][0].Value<DateTime>();
                        T value = token[i][1].Value<T>();
                        //
                        collection.Add(new TimestamedValue<T>(timeStamp, value));
                    }
                    return collection;
                }
                case JTokenType.Object:
                {
                    foreach(JToken child in token.Children())
                    {
                        DateTime timeStamp = DateTime.Parse(((JProperty)child).Name);
                        var value = ((JProperty)child).Value.ToObject<T>();

                        collection.Add(new TimestamedValue<T>(timeStamp, value));
                    }

                    return collection;
                    throw new InvalidOperationException();
                }
                default:
                {
                    throw new NotImplementedException("Что-то пошло не так");
                }
            }
        }
    }
}