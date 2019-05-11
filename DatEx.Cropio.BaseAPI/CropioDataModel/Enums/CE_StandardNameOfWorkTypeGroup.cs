using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using E = DatEx.Cropio.BaseAPI.CE_StandardNameOfWorkTypeGroup;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Стандартное название для группы типов работ </summary>
    public enum CE_StandardNameOfWorkTypeGroup
    {
        /// <summary> Внесение </summary>
        Application,
        /// <summary> Уборка </summary>
        Harvesting,
        /// <summary> Другое </summary>
        Other,
        /// <summary> Сервис </summary>
        Service,
        /// <summary> Обработка почвы </summary>
        Soil,
        /// <summary> Транспорт </summary>
        Transport,
    }

    public class JsonConverter_StandardNameOfWorkTypeGroup : JsonConverter
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
            if(value.GetType() != typeof(E))
                throw new InvalidOperationException();
            writer.WriteValue(((E)value).AsString());
        }
    }

    public static class EnumConverter_StandardNameOfWorkTypeGroup
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
            catch(KeyNotFoundException e)
            {
                String msg = String.Format("При попытке создать елемент перечисления {0} не было найдено соответствие значению \"{1}\"\n", typeof(E), stringValue);
                throw new InvalidOperationException(msg, e);
            }
        }

        private const String Application = "application";
        private const String Harvesting  = "harvesting";
        private const String Other       = "other";
        private const String Service     = "service";
        private const String Soil        = "soil";
        private const String Transport   = "transport";

        private static readonly Dictionary<E, String> MapEnumToString = new Dictionary<E, String>
        {
            { E.Application , Application },
            { E.Harvesting  , Harvesting  },
            { E.Other       , Other       },
            { E.Service     , Service     },
            { E.Soil        , Soil        },
            { E.Transport   , Transport   },
        };

        private static readonly Dictionary<String, E> MapStringToEnum = new Dictionary<String, E>
        {
            { Application , E.Application },
            { Harvesting  , E.Harvesting  },
            { Other       , E.Other       },
            { Service     , E.Service     },
            { Soil        , E.Soil        },
            { Transport   , E.Transport   },
        };
        public static String AsRuString(this E? enumValue)
        {
            return enumValue == null ? "—" : RuMapEnumToString[(E)enumValue];
        }

        private const String RuApplication = "Внесение";
        private const String RuHarvesting  = "Уборка";
        private const String RuOther       = "Другое";
        private const String RuService     = "Сервис";
        private const String RuSoil        = "Обработка почвы";
        private const String RuTransport   = "Транспорт";


        private static readonly Dictionary<E, String> RuMapEnumToString = new Dictionary<E, String>
        {
            { E.Application , RuApplication },
            { E.Harvesting  , RuHarvesting  },
            { E.Other       , RuOther       },
            { E.Service     , RuService     },
            { E.Soil        , RuSoil        },
            { E.Transport   , RuTransport   },
        };
    }
}
