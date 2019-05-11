using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using E = DatEx.Cropio.BaseAPI.CE_SybtypeOfMachine;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Подтип машины </summary>
    public enum CE_SybtypeOfMachine
    {
        /// <summary> Грузовые автомобили </summary>
        Lorrie,
        /// <summary> Самосвал </summary>
        Tipper,
        /// <summary> Легковой автомобиль </summary>
        Car,
        /// <summary> Топливозаправщик </summary>
        FuelBowser,
        /// <summary> Комбайн </summary>
        Harvester,
        /// <summary> Распрыскиватель </summary>
        Sprayer,
        /// <summary> Трактор </summary>
        Tractor,
        /// <summary> Бульдозер </summary>
        Bulldozer,
        /// <summary> Телескопический погрузчик </summary>
        Telehandler,
        /// <summary> Обслуживание </summary>
        Maintenance,
        /// <summary> Микроавтобус </summary>
        Minibus,
        /// <summary> Автокран </summary>
        TruckCrane,
        /// <summary> Другое </summary>
        Other,
    }

    public class JsonConverter_SybtypeOfMachine : JsonConverter
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

    public static class EnumConverter_SybtypeOfMachine
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

        private const String Lorrie      = "lorrie";
        private const String Tipper      = "tipper";
        private const String Car         = "car";
        private const String FuelBowser  = "fuel_bowser";
        private const String Harvester   = "harvester";
        private const String Sprayer     = "sprayer";
        private const String Tractor     = "tractor";
        private const String Buldozer    = "buldozer";
        private const String Telehandler = "telehandler";
        private const String Maintenance = "maintenance";
        private const String Minibus     = "minibus";
        private const String TruckCrane  = "truck_crane";
        private const String Other       = "other";

        private static readonly Dictionary<E, String> MapEnumToString = new Dictionary<E, String>
        {
            { E.Lorrie      , Lorrie      },
            { E.Tipper      , Tipper      },
            { E.Car         , Car         },
            { E.FuelBowser  , FuelBowser  },
            { E.Harvester   , Harvester   },
            { E.Sprayer     , Sprayer     },
            { E.Tractor     , Tractor     },
            { E.Bulldozer   , Buldozer    },
            { E.Telehandler , Telehandler },
            { E.Maintenance , Maintenance },
            { E.Minibus     , Minibus     },
            { E.TruckCrane  , TruckCrane },
            { E.Other       , Other       },
        };

        private static readonly Dictionary<String, E> MapStringToEnum = new Dictionary<String, E>
        {
            { Lorrie      , E.Lorrie      },
            { Tipper      , E.Tipper      },
            { Car         , E.Car         },
            { FuelBowser  , E.FuelBowser  },
            { Harvester   , E.Harvester   },
            { Sprayer     , E.Sprayer     },
            { Tractor     , E.Tractor     },
            { Buldozer    , E.Bulldozer   },
            { Telehandler , E.Telehandler },
            { Maintenance , E.Maintenance },
            { Minibus     , E.Minibus     },
            { TruckCrane  , E.TruckCrane  },
            { Other       , E.Other       },
        };
    }
}
