using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using E = DatEx.Cropio.BaseAPI.CE_TypeOfImplement;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Тип реализации </summary>
    public enum CE_TypeOfImplement
    {
        /// <summary> Глубокорыхлитель </summary>
        Subsoiler,
        /// <summary> Культиватор </summary>
        Cultivator,
        /// <summary> Сеялка </summary>
        Planter,
        /// <summary> Опрыскиватель </summary>
        Sprayer,
        /// <summary> Разбрасыватель </summary>
        Spreader,
        /// <summary> Подъемник </summary>
        Lifter,
        /// <summary> Бункер </summary>
        Bunker,
        /// <summary> Тележка </summary>
        Cart,
        /// <summary> Борона </summary>
        Harrow,
        /// <summary> Грейдер </summary>
        Graider,
        /// <summary> Трейлер </summary>
        Trailer,
        /// <summary> Каток </summary>
        Roller,
        /// <summary> Жатка </summary>
        Reaper,
        /// <summary> Компактер </summary>
        Compactor,
        /// <summary> Тюкопресс </summary>
        Baler,
        /// <summary> Обработка трав </summary>
        GrassHandling,
        /// <summary> Плуг </summary>
        Plow,
        /// <summary> Другое </summary>
        Other, // Все ниже отсутствует в официальной документации по API
        /// <summary> Косилка </summary>
        Mower,
        /// <summary> Сцепка </summary>
        Coupler,
        /// <summary> Бочка </summary>
        Barrel,
        /// <summary> Прицеп </summary>
        Hindcarriage,
        /// <summary> Рыхлитель </summary>
        Ripper,
        /// <summary> Измельчители </summary>
        Shredders
    }

    public class JsonConverter_TypeOfImplement : JsonConverter
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

    public static class EnumConverter_TypeOfImplement
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

        public static String AsStringRu(this E enumValue)
        {
            return MapEnumToStringRu[enumValue];
        }

        private const String Subsoiler     = "subsoiler";
        private const String Cultivator    = "cultivator";
        private const String Planter       = "planter";
        private const String Sprayer       = "sprayer";
        private const String Spreader      = "spreader";
        private const String Lifter        = "lifter";
        private const String Bunker        = "bunker";
        private const String Cart          = "cart";
        private const String Harrow        = "harrow";
        private const String Graider       = "graider";
        private const String Trailer       = "trailer";
        private const String Roller        = "roller";
        private const String Reaper        = "reaper";
        private const String Compactor     = "compactor";
        private const String Baler         = "baler";
        private const String GrassHandling = "grass_handling";
        private const String Plow          = "plow";
        private const String Other         = "other";
        private const String Mower         = "mower";
        private const String Coupler       = "coupler";
        private const String Barrel        = "barrel";
        private const String Hindcarriage  = "hindcarriage";
        private const String Ripper        = "ripper";
        private const String Shredders        = "shredders";

        private static readonly Dictionary<E, String> MapEnumToString = new Dictionary<E, String>
        {
            { E.Subsoiler     , Subsoiler     },
            { E.Cultivator    , Cultivator    },
            { E.Planter       , Planter       },
            { E.Sprayer       , Sprayer       },
            { E.Spreader      , Spreader      },
            { E.Lifter        , Lifter        },
            { E.Bunker        , Bunker        },
            { E.Cart          , Cart          },
            { E.Harrow        , Harrow        },
            { E.Graider       , Graider       },
            { E.Trailer       , Trailer       },
            { E.Roller        , Roller        },
            { E.Reaper        , Reaper        },
            { E.Compactor     , Compactor     },
            { E.Baler         , Baler         },
            { E.GrassHandling , GrassHandling },
            { E.Plow          , Plow          },
            { E.Other         , Other         },
            { E.Mower         , Mower         },
            { E.Coupler       , Coupler       },
            { E.Barrel        , Barrel        },
            { E.Hindcarriage  , Hindcarriage  },
            { E.Ripper        , Ripper        },
            { E.Shredders     , Shredders     },
        };

        private static readonly Dictionary<String, E> MapStringToEnum = new Dictionary<String, E>
        {
            { Subsoiler     , E.Subsoiler     },
            { Cultivator    , E.Cultivator    },
            { Planter       , E.Planter       },
            { Sprayer       , E.Sprayer       },
            { Spreader      , E.Spreader      },
            { Lifter        , E.Lifter        },
            { Bunker        , E.Bunker        },
            { Cart          , E.Cart          },
            { Harrow        , E.Harrow        },
            { Graider       , E.Graider       },
            { Trailer       , E.Trailer       },
            { Roller        , E.Roller        },
            { Reaper        , E.Reaper        },
            { Compactor     , E.Compactor     },
            { Baler         , E.Baler         },
            { GrassHandling , E.GrassHandling },
            { Plow          , E.Plow          },
            { Other         , E.Other         },
            { Mower         , E.Mower         },
            { Coupler       , E.Coupler       },
            { Barrel        , E.Barrel        },
            { Hindcarriage  , E.Hindcarriage  },
            { Ripper        , E.Ripper        },
            { Shredders     , E.Shredders     },
        };

        private const String Subsoiler_Ru     = "Глубокорыхлитель";
        private const String Cultivator_Ru    = "Культиватор";
        private const String Planter_Ru       = "Сеялка";
        private const String Sprayer_Ru       = "Опрыскиватель";
        private const String Spreader_Ru      = "Разбрасыватель";
        private const String Lifter_Ru        = "Подъемник";
        private const String Bunker_Ru        = "Бункер";
        private const String Cart_Ru          = "Тележка";
        private const String Harrow_Ru        = "Борона";
        private const String Graider_Ru       = "Грейдер";
        private const String Trailer_Ru       = "Трейлер";
        private const String Roller_Ru        = "Каток";
        private const String Reaper_Ru        = "Жатка";
        private const String Compactor_Ru     = "Компактер";
        private const String Baler_Ru         = "Тюкопресс";
        private const String GrassHandling_Ru = "Обработка трав";
        private const String Plow_Ru          = "Плуг";
        private const String Other_Ru         = "Другое";
        private const String Mower_Ru         = "Косилка";
        private const String Coupler_Ru       = "Сцепка";
        private const String Barrel_Ru        = "Бочка";
        private const String Hindcarriage_Ru  = "Прицеп";
        private const String Ripper_Ru        = "Рыхлитель";
        private const String Shredders_Ru     = "Измельчители";

        private static readonly Dictionary<E, String> MapEnumToStringRu = new Dictionary<E, String>
        {
            { E.Subsoiler     , Subsoiler_Ru     },
            { E.Cultivator    , Cultivator_Ru    },
            { E.Planter       , Planter_Ru       },
            { E.Sprayer       , Sprayer_Ru       },
            { E.Spreader      , Spreader_Ru      },
            { E.Lifter        , Lifter_Ru        },
            { E.Bunker        , Bunker_Ru        },
            { E.Cart          , Cart_Ru          },
            { E.Harrow        , Harrow_Ru        },
            { E.Graider       , Graider_Ru       },
            { E.Trailer       , Trailer_Ru       },
            { E.Roller        , Roller_Ru        },
            { E.Reaper        , Reaper_Ru        },
            { E.Compactor     , Compactor_Ru     },
            { E.Baler         , Baler_Ru         },
            { E.GrassHandling , GrassHandling_Ru },
            { E.Plow          , Plow_Ru          },
            { E.Other         , Other_Ru         },
            { E.Mower         , Mower_Ru         },
            { E.Coupler       , Coupler_Ru       },
            { E.Barrel        , Barrel_Ru        },
            { E.Hindcarriage  , Hindcarriage_Ru  },
            { E.Ripper        , Ripper_Ru        },
            { E.Shredders     , Shredders_Ru     },
        };
    }
}
