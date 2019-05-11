using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using E = DatEx.Cropio.BaseAPI.CE_AgroOperationStatus;

namespace DatEx.Cropio.BaseAPI
{
    public enum CE_AgroOperationStatus
    {
        /// <summary> Запланировано </summary>
        Planned,
        /// <summary> В прогрессе </summary>
        InProgress,
        /// <summary> Выполнено </summary>
        Done,
        /// <summary> Отменено </summary>
        Canceled
    }
    
    public class JsonConverter_AgroOperationStatus : JsonConverter
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

    public static class EnumConverter_AgroOperationStatus
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

        private const String Planned    = "planned";
        private const String InProgress = "in_progress";
        private const String Done       = "done";
        private const String Canceled   = "canceled";

        private static readonly Dictionary<E, String> MapEnumToString = new Dictionary<E, String>
        {
            { E.Planned    , Planned    },
            { E.InProgress , InProgress },
            { E.Done       , Done       },
            { E.Canceled   , Canceled   }
        };

        private static readonly Dictionary<String, E> MapStringToEnum = new Dictionary<String, E>
        {
            { Planned    , E.Planned    },
            { InProgress , E.InProgress },
            { Done       , E.Done       },
            { Canceled   , E.Canceled   }
        };
    }
}
