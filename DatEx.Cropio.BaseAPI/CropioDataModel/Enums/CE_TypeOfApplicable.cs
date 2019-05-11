using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using E = DatEx.Cropio.BaseAPI.CE_TypeOfApplicable;

namespace DatEx.Cropio.BaseAPI
{
    public enum CE_TypeOfApplicable
    {
        /// <summary> Семена </summary>
        Seed,
        /// <summary> Удобрение </summary>
        Fertilizer,
        /// <summary> Химикат </summary>
        Chemical
    }

    // "Seed", "Fertilizer", "Chemical"

    public class JsonConverter_TypeOfApplicable : JsonConverter
    {
        public override Boolean CanConvert(Type objectType)
        {
            return objectType == typeof(E);
        }

        public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
        {
            if(reader.TokenType == JsonToken.Null) return default(E?);
            JToken token = JToken.Load(reader);
            E enumValue;
            token.Value<String>().AsEnum(out enumValue);
            return enumValue;
        }

        public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
        {
            if(value.GetType() != typeof(E)) throw new InvalidOperationException();
            writer.WriteValue(((E)value).AsString());
        }
    }

    public static class EnumConverter_TypeOfApplicable
    {
        public static String AsString(this E enumValue)
        {
            return MapEnumToString[enumValue];
        }

        public static void AsEnum(this String stringValue, out E outputValue)
        {
            try
            {
                outputValue = MapStringToEnum[stringValue];
            }
            catch (KeyNotFoundException e)
            {
                String msg = String.Format("При попытке создать елемент перечисления {0} не было найдено соответствие значению \"{1}\"\n", typeof(E), stringValue);
                throw new InvalidOperationException(msg, e);
            }
        }

        private const String Seed       = "Seed";
        private const String Fertilizer = "Fertilizer";
        private const String Chemical   = "Chemical";

        private static readonly Dictionary<E, String> MapEnumToString = new Dictionary<E, String>
        {
            { E.Seed       , Seed       },
            { E.Fertilizer , Fertilizer },
            { E.Chemical   , Chemical   }
        };

        private static readonly Dictionary<String, E> MapStringToEnum = new Dictionary<String, E>
        {
            { Seed       , E.Seed       },
            { Fertilizer , E.Fertilizer },
            { Chemical   , E.Chemical   }
        };
    }
}