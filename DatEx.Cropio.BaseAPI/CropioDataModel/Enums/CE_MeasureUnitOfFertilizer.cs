﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using E = DatEx.Cropio.BaseAPI.CE_MeasureUnitOfFertilizer;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Ед. измерения удобрений </summary>
    public enum CE_MeasureUnitOfFertilizer
    {
        /// <summary> Литры </summary>
        Liter,
        /// <summary> Килограммы </summary>
        Kg
    }

    public class JsonConverter_MeasureUnitOfFertilizer : JsonConverter
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

    public static class EnumConverter_MeasureUnitOfFertilizer
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

        private const String Liter = "liter";
        private const String Kg    = "kg";

        private static readonly Dictionary<E, String> MapEnumToString = new Dictionary<E, String>
        {
            { E.Liter , Liter },
            { E.Kg    , Kg    },
        };

        private static readonly Dictionary<String, E> MapStringToEnum = new Dictionary<String, E>
        {
            { Liter , E.Liter },
            { Kg    , E.Kg    },
        };
    }
}
