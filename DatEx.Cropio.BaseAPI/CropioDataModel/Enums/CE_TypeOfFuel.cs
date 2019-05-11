using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using E = DatEx.Cropio.BaseAPI.CE_TypeOfFuel;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Тип топлива </summary>
    public enum CE_TypeOfFuel
    {
        /// <summary> Бензин </summary>
        Gas,
        /// <summary> Дизтопливо </summary>
        Diesel,
        /// <summary> Газ </summary>
        NaturalGas,
        /// <summary> Другое </summary>
        Other,
    }
    
    public class JsonConverter_TypeOfFuel : JsonConverter
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

    public static class EnumConverter_TypeOfFuel
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

        private const String Gas         = "gas";
        private const String Diesel      = "diesel";
        private const String NaturalGas  = "natural_gas";
        private const String Other       = "other";

        private static readonly Dictionary<E, String> MapEnumToString = new Dictionary<E, String>
        {
            { E.Gas        , Gas        },
            { E.Diesel     , Diesel     },
            { E.NaturalGas , NaturalGas },
            { E.Other      , Other      },
        };

        private static readonly Dictionary<String, E> MapStringToEnum = new Dictionary<String, E>
        {
            { Gas        , E.Gas        },
            { Diesel     , E.Diesel     },
            { NaturalGas , E.NaturalGas },
            { Other      , E.Other      },
        };
    }
}
