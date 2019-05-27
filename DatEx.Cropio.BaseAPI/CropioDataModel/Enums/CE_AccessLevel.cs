using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using E = DatEx.Cropio.BaseAPI.CE_AccessLevel;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Уровень доступа </summary>
    public enum CE_AccessLevel
    {
        /// <summary> Без доступа </summary>
        NoAccess = 1,
        /// <summary> Только чтение </summary>
        Read = 2,
        /// <summary> Менеджер </summary>
        Manage = 3,
        /// <summary> Полный доступ </summary>
        FullAccess = 4,
    }    

    public class JsonConverter_AccessLevel : JsonConverter
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

    public static class EnumConverter_AccessLevel
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

        private const String FullAccess = "full_access";
        private const String Manage     = "manage";
        private const String NoAccess   = "no_access";
        private const String Read       = "read";

        private static readonly Dictionary<E, String> MapEnumToString = new Dictionary<E, String>
        {
            { E.FullAccess  , FullAccess },
            { E.Manage      , Manage     },
            { E.NoAccess    , NoAccess   },
            { E.Read        , Read       },
        };

        private static readonly Dictionary<String, E> MapStringToEnum = new Dictionary<String, E>
        {
            { FullAccess  , E.FullAccess },
            { Manage      , E.Manage     },
            { NoAccess    , E.NoAccess   },
            { Read        , E.Read       },
        };
    }
}
