﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using E = DatEx.Cropio.BaseAPI.CE_TypeOfChemical;

namespace DatEx.Cropio.BaseAPI
{
    public enum CE_TypeOfChemical
    {
        Bactericide,
        Herbicide,
        Insecticide,
        Fungicide,
        GrowthRegulator,
        SeedTreatment,
        Other,
    }

    public class JsonConverter_TypeOfChemical : JsonConverter
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

    public static class EnumConverter_TypeOfChemical
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

        private const String Bactericide     = "bactericide";
        private const String Herbicide       = "herbicide";
        private const String Insecticide     = "insecticide";
        private const String Fungicide       = "fungicide";
        private const String GrowthRegulator = "growth_regulator";
        private const String SeedTreatment   = "seed_treatment";
        private const String Other           = "other";

        private static readonly Dictionary<E, String> MapEnumToString = new Dictionary<E, String>
        {
            { E.Bactericide     , Bactericide     },
            { E.Herbicide       , Herbicide       },
            { E.Insecticide     , Insecticide     },
            { E.Fungicide       , Fungicide       },
            { E.GrowthRegulator , GrowthRegulator },
            { E.SeedTreatment   , SeedTreatment   },
            { E.Other           , Other           },
        };

        private static readonly Dictionary<String, E> MapStringToEnum = new Dictionary<String, E>
        {
            { Bactericide     , E.Bactericide     },
            { Herbicide       , E.Herbicide       },
            { Insecticide     , E.Insecticide     },
            { Fungicide       , E.Fungicide       },
            { GrowthRegulator , E.GrowthRegulator },
            { SeedTreatment   , E.SeedTreatment   },
            { Other           , E.Other           },
        };
    }
}
