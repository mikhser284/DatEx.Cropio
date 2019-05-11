using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using E = DatEx.Cropio.BaseAPI.CE_CropStandardName;

namespace DatEx.Cropio.BaseAPI
{
    public enum CE_CropStandardName
    {
        /// <summary> Ячмень яровой </summary>
        BarleySpring = 1,
        /// <summary> Пшеница озимая </summary>
        WheatWinter = 2,
        /// <summary> Соя </summary>
        Soya = 3,
        /// <summary> Подсолнечник </summary>
        Sunflower = 4,
        /// <summary>  Кукуруза</summary>
        Maize = 5,
        /// <summary> Овес яровой </summary>
        AvenaSpring = 6,
        /// <summary> Рапс озимый </summary>
        OilSeedRapsWinter = 7,
        /// <summary> Пар </summary>
        Fallow = 8,
        /// <summary> Пшеница яровая </summary>
        WheatSpring = 11,
        /// <summary> Картофель </summary>
        Potatoes = 12,
        /// <summary> Лен </summary>
        Linum = 13,
        /// <summary> Горох </summary>
        Pea = 15,
        /// <summary> Рожь озимая </summary>
        RyeWinter = 17,
        /// <summary> Люцерна </summary>
        Medicago = 18,
        /// <summary> Рожь яровая </summary>
        RyeSpring = 19,
        /// <summary> Овес озимый </summary>
        AvenaWinter = 20,
        /// <summary> Ячмень озимый </summary>
        BarleyWinter = 21,
        /// <summary> Гречиха </summary>
        Buckwheat = 22,
        /// <summary> Нут </summary>
        Chickpea = 23,
        /// <summary> Грейпфрут </summary>
        Grapefruit = 24,
        /// <summary> Виноград </summary>
        Grapevine = 25,
        /// <summary> Лимон </summary>
        Lemon = 26,
        /// <summary> Лайм </summary>
        Lime = 27,
        /// <summary> Просо </summary>
        Millet = 28,
        /// <summary> Рапс яровой </summary>
        OilSeedRapsSpring = 29,
        /// <summary> Апельсин </summary>
        Orange = 30,
        /// <summary> Мак </summary>
        Papaver = 31,
        /// <summary> Персик </summary>
        Peach = 32,
        /// <summary> Арахис </summary>
        Peanut = 33,
        /// <summary> Гранат </summary>
        Pomegranate = 34,
        /// <summary> Помело </summary>
        Pomelo = 35,
        /// <summary> Рис </summary>
        Rice = 36,
        /// <summary> Сафлор </summary>
        Safflower = 37,
        /// <summary> Эспарцет </summary>
        Sainfoin = 38,
        /// <summary> Сорго </summary>
        Sorghum = 39,
        /// <summary> Суданская трава </summary>
        SudanGrass = 40,
        /// <summary> Сахарная свекла </summary>
        SugarBeet = 41,
        /// <summary> Сахарный тростник </summary>
        Sugarcane = 42,
        /// <summary> Тритикале яровой </summary>
        TriticaleSpring = 43,
        /// <summary> Тритикале озимый </summary>
        TriticaleWinter = 44
    }

    public class JsonConverter_CropStandardName : JsonConverter
    {
        public override Boolean CanConvert(Type objectType)
        {
            return objectType == typeof(E);
        }

        public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
        {
            if(reader.TokenType == JsonToken.Null) return default(E?);
            JToken token = JToken.Load(reader);
            E? enumValue;
            token.Value<String>().AsEnum(out enumValue);
            return enumValue;
        }

        public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
        {
            if(value.GetType() != typeof(E)) throw new InvalidOperationException();
            writer.WriteValue(((E)value).AsString());
        }
    }

    public static class EnumConverter_CropStandardName
    {
        public static String AsString(this E enumValue)
        {
            return MapEnumToString[enumValue];
        }

        public static void AsEnum(this String stringValue, out E? outputValue)
        {
            if(stringValue == null || stringValue == "null")
            {
                outputValue = null;
                return;
            }

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

        private const String BarleySpring      = "barley_spring";
        private const String WheatWinter       = "wheat_winter";
        private const String Soya              = "soya";
        private const String Sunflower         = "sunflower";
        private const String Maize             = "maize";
        private const String AvenaSpring       = "avena_spring";
        private const String OilSeedRapsWinter = "oil_seed_raps_winter";
        private const String Fallow            = "fallow";
        private const String WheatSpring       = "wheat_spring";
        private const String Potatoes          = "potatoes";
        private const String Linum             = "linum";
        private const String Pea               = "pea";
        private const String RyeWinter         = "rye_winter";
        private const String Medicago          = "medicago";
        private const String RyeSpring         = "rye_spring";
        private const String AvenaWinter       = "avena_winter";
        private const String BarleyWinter      = "barley_winter";
        private const String Buckwheat         = "buckwheat";
        private const String Chickpea          = "chickpea";
        private const String Grapefruit        = "grapefruit";
        private const String Grapevine         = "grapevine";
        private const String Lemon             = "lemon";
        private const String Lime              = "lime";
        private const String Millet            = "millet";
        private const String OilSeedRapsSpring = "oil_seed_raps_spring";
        private const String Orange            = "orange";
        private const String Papaver           = "papaver";
        private const String Peach             = "peach";
        private const String Peanut            = "peanut";
        private const String Pomegranate       = "pomegranate";
        private const String Pomelo            = "pomelo";
        private const String Rice              = "rice";
        private const String Safflower         = "safflower";
        private const String Sainfoin          = "sainfoin";
        private const String Sorghum           = "sorghum";
        private const String SudanGrass        = "sudan_grass";
        private const String SugarBeet         = "sugar_beet";
        private const String Sugarcane         = "sugarcane";
        private const String TriticaleSpring   = "triticale_spring";
        private const String TriticaleWinter   = "triticale_winter";

        private static readonly Dictionary<E, String> MapEnumToString = new Dictionary<E, String>()
        {
            { E.BarleySpring      , BarleySpring      },
            { E.WheatWinter       , WheatWinter       },
            { E.Soya              , Soya              },
            { E.Sunflower         , Sunflower         },
            { E.Maize             , Maize             },
            { E.AvenaSpring       , AvenaSpring       },
            { E.OilSeedRapsWinter , OilSeedRapsWinter },
            { E.Fallow            , Fallow            },
            { E.WheatSpring       , WheatSpring       },
            { E.Potatoes          , Potatoes          },
            { E.Linum             , Linum             },
            { E.Pea               , Pea               },
            { E.RyeWinter         , RyeWinter         },
            { E.Medicago          , Medicago          },
            { E.RyeSpring         , RyeSpring         },
            { E.AvenaWinter       , AvenaWinter       },
            { E.BarleyWinter      , BarleyWinter      },
            { E.Buckwheat         , Buckwheat         },
            { E.Chickpea          , Chickpea          },
            { E.Grapefruit        , Grapefruit        },
            { E.Grapevine         , Grapevine         },
            { E.Lemon             , Lemon             },
            { E.Lime              , Lime              },
            { E.Millet            , Millet            },
            { E.OilSeedRapsSpring , OilSeedRapsSpring },
            { E.Orange            , Orange            },
            { E.Papaver           , Papaver           },
            { E.Peach             , Peach             },
            { E.Peanut            , Peanut            },
            { E.Pomegranate       , Pomegranate       },
            { E.Pomelo            , Pomelo            },
            { E.Rice              , Rice              },
            { E.Safflower         , Safflower         },
            { E.Sainfoin          , Sainfoin          },
            { E.Sorghum           , Sorghum           },
            { E.SudanGrass        , SudanGrass        },
            { E.SugarBeet         , SugarBeet         },
            { E.Sugarcane         , Sugarcane         },
            { E.TriticaleSpring   , TriticaleSpring   },
            { E.TriticaleWinter   , TriticaleWinter   },
        };

        private static readonly Dictionary<String, E> MapStringToEnum = new Dictionary<String, E>()
        {
            { BarleySpring      , E.BarleySpring      },
            { WheatWinter       , E.WheatWinter       },
            { Soya              , E.Soya              },
            { Sunflower         , E.Sunflower         },
            { Maize             , E.Maize             },
            { AvenaSpring       , E.AvenaSpring       },
            { OilSeedRapsWinter , E.OilSeedRapsWinter },
            { Fallow            , E.Fallow            },
            { WheatSpring       , E.WheatSpring       },
            { Potatoes          , E.Potatoes          },
            { Linum             , E.Linum             },
            { Pea               , E.Pea               },
            { RyeWinter         , E.RyeWinter         },
            { Medicago          , E.Medicago          },
            { RyeSpring         , E.RyeSpring         },
            { AvenaWinter       , E.AvenaWinter       },
            { BarleyWinter      , E.BarleyWinter      },
            { Buckwheat         , E.Buckwheat         },
            { Chickpea          , E.Chickpea          },
            { Grapefruit        , E.Grapefruit        },
            { Grapevine         , E.Grapevine         },
            { Lemon             , E.Lemon             },
            { Lime              , E.Lime              },
            { Millet            , E.Millet            },
            { OilSeedRapsSpring , E.OilSeedRapsSpring },
            { Orange            , E.Orange            },
            { Papaver           , E.Papaver           },
            { Peach             , E.Peach             },
            { Peanut            , E.Peanut            },
            { Pomegranate       , E.Pomegranate       },
            { Pomelo            , E.Pomelo            },
            { Rice              , E.Rice              },
            { Safflower         , E.Safflower         },
            { Sainfoin          , E.Sainfoin          },
            { Sorghum           , E.Sorghum           },
            { SudanGrass        , E.SudanGrass        },
            { SugarBeet         , E.SugarBeet         },
            { Sugarcane         , E.Sugarcane         },
            { TriticaleSpring   , E.TriticaleSpring   },
            { TriticaleWinter   , E.TriticaleWinter   },
        };
    }
}
