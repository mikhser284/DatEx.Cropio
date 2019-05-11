using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using E = DatEx.Cropio.BaseAPI.CE_StandardNameOfWorkType;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Стандартное название для группы типа работ </summary>
    public enum CE_StandardNameOfWorkType
    {
        /// <summary> Внесение. Другое </summary>
        Application_Other = 1001,
        /// <summary> Внесение. Пересев </summary>
        Application_OverSowing = 1002,
        /// <summary> Внесение. Сев </summary>
        Application_Sowing = 1003,
        /// <summary> Внесение. Распыление </summary>
        Application_Spraying = 1004,
        /// <summary> Внесение. Распространение </summary>
        Application_Spreading = 1005,

        /// <summary> Уборка. Сбор урожая </summary>
        Harvesting_Harvesting = 2001,
        /// <summary> Уборка. Другое </summary>
        Harvesting_Other = 2002,
        
        /// <summary> Другое. Агро </summary>
        Other_Agri = 3001,
        /// <summary> Другое. Заправка топливом </summary>
        Other_FuelTanking = 3002,
        /// <summary> Другое. Уборка мусора </summary>
        Other_GarbageWorks = 3003,
        /// <summary> Другое. Погрузочные работы </summary>
        Other_LoadingWorks = 3004,
        /// <summary> Другое. Другое </summary>
        Other_Other = 3005,
        /// <summary> Другое. Дорожные работы </summary>
        Other_RoadWorks = 3006,
        /// <summary> Другое. Уборка снега </summary>
        Other_SnowRemoval = 3007,
        /// <summary> Другое. Перенос </summary>
        Other_Transfer = 3008,
        /// <summary> Другое. Работы на територии </summary>
        Other_WorksInTerritory = 3009,

        /// <summary> Сервис. Административные работы </summary>
        Service_AdministrativeWorks = 4001,
        /// <summary> Сервис. Контроль полевых работ </summary>
        Service_FieldWorksControl = 4002,
        /// <summary> Сервис. Мониторинг полей </summary>
        Service_FieldsMonitoring = 4003,
        /// <summary> Сервис. Другое </summary>
        Service_Other = 4004,
        /// <summary> Сервис. Другие сельськохозяйственные работы </summary>
        Service_OtherFarmworks = 4005,
        /// <summary> Сервис. Техническая поддержка </summary>
        Service_TechnicalSupport = 4006,

        /// <summary> Обработка почвы. Вырубка </summary>
        Soil_Chopping = 5001,
        /// <summary> Обработка почвы. Культивирование </summary>
        Soil_Cultivation = 5002,
        /// <summary> Обработка почвы. Бороздование </summary>
        Soil_CuttingFurrows = 5003,
        /// <summary> Обработка почвы. Дискование </summary>
        Soil_Discing = 5004,
        /// <summary> Обработка почвы. Мульчирование пыли </summary>
        Soil_DustMulching = 5005,
        /// <summary> Обработка почвы. Боронование </summary>
        Soil_Harrowing = 5006,
        /// <summary> Обработка почвы. Междурядное культивирование </summary>
        Soil_InrowCultivation = 5007,
        /// <summary> Обработка почвы. Расчистка деревьев и кустарников </summary>
        Soil_LandClearingOfTreesAndBrush = 5008,
        /// <summary> Обработка почвы. Другое </summary>
        Soil_Other = 5009,
        /// <summary> Обработка почвы. Вспашка </summary>
        Soil_Plowing = 5010,
        /// <summary> Обработка почвы. Корчевание </summary>
        Soil_Pulling = 5011,
        /// <summary> Обработка почвы. Каткование </summary>
        Soil_Rolling = 5012,
        /// <summary> Обработка почвы. Желобование </summary>
        Soil_Slotting = 5013,
        /// <summary> Обработка почвы. Рыхление </summary>
        Soil_Subsoiling = 5014,
        
        /// <summary> Транспорт. Химикаты </summary>
        Transport_Chemicals = 6001,
        /// <summary> Транспорт. Удобрения </summary>
        Transport_Fertilizers = 6002,
        /// <summary> Транспорт. Еда </summary>
        Transport_Food = 6003,
        /// <summary> Транспорт. Зерно </summary>
        Transport_Grain = 6004,
        /// <summary> Транспорт. Машины </summary>
        Transport_Machinery = 6005,
        /// <summary> Транспорт. Другое </summary>
        Transport_Other = 6006,
        /// <summary> Транспорт. Люди </summary>
        Transport_People = 6007,
        /// <summary> Транспорт. Семена </summary>
        Transport_Seeds = 6008,
        /// <summary> Транспорт. Запасные части </summary>
        Transport_SpareParts = 6009,
        /// <summary> Транспорт. Вода </summary>
        Transport_Water = 6010,
    }

    public class JsonConverter_StandardNameOfWorkType : JsonConverter
    {
        public override Boolean CanConvert(Type objectType)
        {
            return objectType == typeof(E);
        }

        public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
        {
            if(reader.TokenType == JsonToken.Null)
                return default(E?);
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

    public static class EnumConverter_StandardNameOfWorkType
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

        private const String Application_Other                = "application.other";
        private const String Application_OverSowing           = "application.over_sowing";
        private const String Application_Sowing               = "application.sowing";
        private const String Application_Spraying             = "application.spraying";
        private const String Application_Spreading            = "application.spreading";
        private const String Harvesting_Harvesting            = "harvesting.harvesting";
        private const String Harvesting_Other                 = "harvesting.other";
        private const String Other_Agri                       = "other.agri";
        private const String Other_FuelTanking                = "other.fuel_tanking";
        private const String Other_GarbageWorks               = "other.garbage_works";
        private const String Other_LoadingWorks               = "other.loading_works";
        private const String Other_Other                      = "other.other";
        private const String Other_RoadWorks                  = "other.road_works";
        private const String Other_SnowRemoval                = "other.snow_removal";
        private const String Other_Transfer                   = "other.transfer";
        private const String Other_WorksInTerritory           = "other.works_in_territory";
        private const String Service_AdministrativeWorks      = "service.administrative_works";
        private const String Service_FieldWorksControl        = "service.field_works_control";
        private const String Service_FieldsMonitoring         = "service.fields_monitoring";
        private const String Service_Other                    = "service.other";
        private const String Service_OtherFarmworks           = "service.other_farmworks";
        private const String Service_TechnicalSupport         = "service.technical_support";
        private const String Soil_Chopping                    = "soil.chopping";
        private const String Soil_Cultivation                 = "soil.cultivation";
        private const String Soil_CuttingFurrows              = "soil.cutting_furrows";
        private const String Soil_Discing                     = "soil.discing";
        private const String Soil_DustMulching                = "soil.dust_mulching";
        private const String Soil_Harrowing                   = "soil.harrowing";
        private const String Soil_InrowCultivation            = "soil.inrow_cultivation";
        private const String Soil_LandClearingOfTreesAndBrush = "soil.land_clearing_of_trees_and_brush";
        private const String Soil_Other                       = "soil.other";
        private const String Soil_Plowing                     = "soil.plowing";
        private const String Soil_Pulling                     = "soil.pulling";
        private const String Soil_Rolling                     = "soil.rolling";
        private const String Soil_Slotting                    = "soil.slotting";
        private const String Soil_Subsoiling                  = "soil.subsoiling";
        private const String Transport_Chemicals              = "transport.chemicals";
        private const String Transport_Fertilizers            = "transport.fertilizers";
        private const String Transport_Food                   = "transport.food";
        private const String Transport_Grain                  = "transport.grain";
        private const String Transport_Machinery              = "transport.machinery";
        private const String Transport_Other                  = "transport.other";
        private const String Transport_People                 = "transport.people";
        private const String Transport_Seeds                  = "transport.seeds";
        private const String Transport_SpareParts             = "transport.spare_parts";
        private const String Transport_Water                  = "transport.water";

        private static readonly Dictionary<E, String> MapEnumToString = new Dictionary<E, String>
        {
            { E.Application_Other                , Application_Other                },
            { E.Application_OverSowing           , Application_OverSowing           },
            { E.Application_Sowing               , Application_Sowing               },
            { E.Application_Spraying             , Application_Spraying             },
            { E.Application_Spreading            , Application_Spreading            },
            { E.Harvesting_Harvesting            , Harvesting_Harvesting            },
            { E.Harvesting_Other                 , Harvesting_Other                 },
            { E.Other_Agri                       , Other_Agri                       },
            { E.Other_FuelTanking                , Other_FuelTanking                },
            { E.Other_GarbageWorks               , Other_GarbageWorks               },
            { E.Other_LoadingWorks               , Other_LoadingWorks               },
            { E.Other_Other                      , Other_Other                      },
            { E.Other_RoadWorks                  , Other_RoadWorks                  },
            { E.Other_SnowRemoval                , Other_SnowRemoval                },
            { E.Other_Transfer                   , Other_Transfer                   },
            { E.Other_WorksInTerritory           , Other_WorksInTerritory           },
            { E.Service_AdministrativeWorks      , Service_AdministrativeWorks      },
            { E.Service_FieldWorksControl        , Service_FieldWorksControl        },
            { E.Service_FieldsMonitoring         , Service_FieldsMonitoring         },
            { E.Service_Other                    , Service_Other                    },
            { E.Service_OtherFarmworks           , Service_OtherFarmworks           },
            { E.Service_TechnicalSupport         , Service_TechnicalSupport         },
            { E.Soil_Chopping                    , Soil_Chopping                    },
            { E.Soil_Cultivation                 , Soil_Cultivation                 },
            { E.Soil_CuttingFurrows              , Soil_CuttingFurrows              },
            { E.Soil_Discing                     , Soil_Discing                     },
            { E.Soil_DustMulching                , Soil_DustMulching                },
            { E.Soil_Harrowing                   , Soil_Harrowing                   },
            { E.Soil_InrowCultivation            , Soil_InrowCultivation            },
            { E.Soil_LandClearingOfTreesAndBrush , Soil_LandClearingOfTreesAndBrush },
            { E.Soil_Other                       , Soil_Other                       },
            { E.Soil_Plowing                     , Soil_Plowing                     },
            { E.Soil_Pulling                     , Soil_Pulling                     },
            { E.Soil_Rolling                     , Soil_Rolling                     },
            { E.Soil_Slotting                    , Soil_Slotting                    },
            { E.Soil_Subsoiling                  , Soil_Subsoiling                  },
            { E.Transport_Chemicals              , Transport_Chemicals              },
            { E.Transport_Fertilizers            , Transport_Fertilizers            },
            { E.Transport_Food                   , Transport_Food                   },
            { E.Transport_Grain                  , Transport_Grain                  },
            { E.Transport_Machinery              , Transport_Machinery              },
            { E.Transport_Other                  , Transport_Other                  },
            { E.Transport_People                 , Transport_People                 },
            { E.Transport_Seeds                  , Transport_Seeds                  },
            { E.Transport_SpareParts             , Transport_SpareParts             },
            { E.Transport_Water                  , Transport_Water                  },
        };

        private static readonly Dictionary<String, E> MapStringToEnum = new Dictionary<String, E>
        {
            { Application_Other                , E.Application_Other                },
            { Application_OverSowing           , E.Application_OverSowing           },
            { Application_Sowing               , E.Application_Sowing               },
            { Application_Spraying             , E.Application_Spraying             },
            { Application_Spreading            , E.Application_Spreading            },
            { Harvesting_Harvesting            , E.Harvesting_Harvesting            },
            { Harvesting_Other                 , E.Harvesting_Other                 },
            { Other_Agri                       , E.Other_Agri                       },
            { Other_FuelTanking                , E.Other_FuelTanking                },
            { Other_GarbageWorks               , E.Other_GarbageWorks               },
            { Other_LoadingWorks               , E.Other_LoadingWorks               },
            { Other_Other                      , E.Other_Other                      },
            { Other_RoadWorks                  , E.Other_RoadWorks                  },
            { Other_SnowRemoval                , E.Other_SnowRemoval                },
            { Other_Transfer                   , E.Other_Transfer                   },
            { Other_WorksInTerritory           , E.Other_WorksInTerritory           },
            { Service_AdministrativeWorks      , E.Service_AdministrativeWorks      },
            { Service_FieldWorksControl        , E.Service_FieldWorksControl        },
            { Service_FieldsMonitoring         , E.Service_FieldsMonitoring         },
            { Service_Other                    , E.Service_Other                    },
            { Service_OtherFarmworks           , E.Service_OtherFarmworks           },
            { Service_TechnicalSupport         , E.Service_TechnicalSupport         },
            { Soil_Chopping                    , E.Soil_Chopping                    },
            { Soil_Cultivation                 , E.Soil_Cultivation                 },
            { Soil_CuttingFurrows              , E.Soil_CuttingFurrows              },
            { Soil_Discing                     , E.Soil_Discing                     },
            { Soil_DustMulching                , E.Soil_DustMulching                },
            { Soil_Harrowing                   , E.Soil_Harrowing                   },
            { Soil_InrowCultivation            , E.Soil_InrowCultivation            },
            { Soil_LandClearingOfTreesAndBrush , E.Soil_LandClearingOfTreesAndBrush },
            { Soil_Other                       , E.Soil_Other                       },
            { Soil_Plowing                     , E.Soil_Plowing                     },
            { Soil_Pulling                     , E.Soil_Pulling                     },
            { Soil_Rolling                     , E.Soil_Rolling                     },
            { Soil_Slotting                    , E.Soil_Slotting                    },
            { Soil_Subsoiling                  , E.Soil_Subsoiling                  },
            { Transport_Chemicals              , E.Transport_Chemicals              },
            { Transport_Fertilizers            , E.Transport_Fertilizers            },
            { Transport_Food                   , E.Transport_Food                   },
            { Transport_Grain                  , E.Transport_Grain                  },
            { Transport_Machinery              , E.Transport_Machinery              },
            { Transport_Other                  , E.Transport_Other                  },
            { Transport_People                 , E.Transport_People                 },
            { Transport_Seeds                  , E.Transport_Seeds                  },
            { Transport_SpareParts             , E.Transport_SpareParts             },
            { Transport_Water                  , E.Transport_Water                  },
        };

        public static String AsRuString(this E? enumValue)
        {
            if(enumValue == null) return "—";
            return RuMapEnumToString[(E)enumValue];
        }

        private const String RuApplication_Other                = "Внесение. Другое";
        private const String RuApplication_OverSowing           = "Внесение. Пересев";
        private const String RuApplication_Sowing               = "Внесение. Сев";
        private const String RuApplication_Spraying             = "Внесение. Распыление";
        private const String RuApplication_Spreading            = "Внесение. Распространение";
        private const String RuHarvesting_Harvesting            = "Уборка. Сбор урожая";
        private const String RuHarvesting_Other                 = "Уборка. Другое";
        private const String RuOther_Agri                       = "Другое. Агро";
        private const String RuOther_FuelTanking                = "Другое. Заправка топливом";
        private const String RuOther_GarbageWorks               = "Другое. Уборка мусора";
        private const String RuOther_LoadingWorks               = "Другое. Погрузочные работы";
        private const String RuOther_Other                      = "Другое. Другое";
        private const String RuOther_RoadWorks                  = "Другое. Дорожные работы";
        private const String RuOther_SnowRemoval                = "Другое. Уборка снега";
        private const String RuOther_Transfer                   = "Другое. Перенос";
        private const String RuOther_WorksInTerritory           = "Другое. Работы на територии";
        private const String RuService_AdministrativeWorks      = "Сервис. Административные работы";
        private const String RuService_FieldWorksControl        = "Сервис. Контроль полевых работ";
        private const String RuService_FieldsMonitoring         = "Сервис. Мониторинг полей";
        private const String RuService_Other                    = "Сервис. Другое";
        private const String RuService_OtherFarmworks           = "Сервис. Другие сельськохозяйственные работы";
        private const String RuService_TechnicalSupport         = "Сервис. Техническая поддержка";
        private const String RuSoil_Chopping                    = "Обработка почвы. Вырубка";
        private const String RuSoil_Cultivation                 = "Обработка почвы. Культивирование";
        private const String RuSoil_CuttingFurrows              = "Обработка почвы. Бороздование";
        private const String RuSoil_Discing                     = "Обработка почвы. Дискование";
        private const String RuSoil_DustMulching                = "Обработка почвы. Мульчирование пыли";
        private const String RuSoil_Harrowing                   = "Обработка почвы. Боронование";
        private const String RuSoil_InrowCultivation            = "Обработка почвы. Междурядное культивирование";
        private const String RuSoil_LandClearingOfTreesAndBrush = "Обработка почвы. Расчистка деревьев и кустарников";
        private const String RuSoil_Other                       = "Обработка почвы. Другое";
        private const String RuSoil_Plowing                     = "Обработка почвы. Вспашка";
        private const String RuSoil_Pulling                     = "Обработка почвы. Корчевание";
        private const String RuSoil_Rolling                     = "Обработка почвы. Каткование";
        private const String RuSoil_Slotting                    = "Обработка почвы. Желобование";
        private const String RuSoil_Subsoiling                  = "Обработка почвы. Рыхление";
        private const String RuTransport_Chemicals              = "Транспорт. Химикаты";
        private const String RuTransport_Fertilizers            = "Транспорт. Удобрения";
        private const String RuTransport_Food                   = "Транспорт. Еда";
        private const String RuTransport_Grain                  = "Транспорт. Зерно";
        private const String RuTransport_Machinery              = "Транспорт. Машины";
        private const String RuTransport_Other                  = "Транспорт. Другое";
        private const String RuTransport_People                 = "Транспорт. Люди";
        private const String RuTransport_Seeds                  = "Транспорт. Семена";
        private const String RuTransport_SpareParts             = "Транспорт. Запасные части";
        private const String RuTransport_Water                  = "Транспорт. Вода";

        private static readonly Dictionary<E, String> RuMapEnumToString = new Dictionary<E, String>
        {
            { E.Application_Other                , RuApplication_Other                },
            { E.Application_OverSowing           , RuApplication_OverSowing           },
            { E.Application_Sowing               , RuApplication_Sowing               },
            { E.Application_Spraying             , RuApplication_Spraying             },
            { E.Application_Spreading            , RuApplication_Spreading            },
            { E.Harvesting_Harvesting            , RuHarvesting_Harvesting            },
            { E.Harvesting_Other                 , RuHarvesting_Other                 },
            { E.Other_Agri                       , RuOther_Agri                       },
            { E.Other_FuelTanking                , RuOther_FuelTanking                },
            { E.Other_GarbageWorks               , RuOther_GarbageWorks               },
            { E.Other_LoadingWorks               , RuOther_LoadingWorks               },
            { E.Other_Other                      , RuOther_Other                      },
            { E.Other_RoadWorks                  , RuOther_RoadWorks                  },
            { E.Other_SnowRemoval                , RuOther_SnowRemoval                },
            { E.Other_Transfer                   , RuOther_Transfer                   },
            { E.Other_WorksInTerritory           , RuOther_WorksInTerritory           },
            { E.Service_AdministrativeWorks      , RuService_AdministrativeWorks      },
            { E.Service_FieldWorksControl        , RuService_FieldWorksControl        },
            { E.Service_FieldsMonitoring         , RuService_FieldsMonitoring         },
            { E.Service_Other                    , RuService_Other                    },
            { E.Service_OtherFarmworks           , RuService_OtherFarmworks           },
            { E.Service_TechnicalSupport         , RuService_TechnicalSupport         },
            { E.Soil_Chopping                    , RuSoil_Chopping                    },
            { E.Soil_Cultivation                 , RuSoil_Cultivation                 },
            { E.Soil_CuttingFurrows              , RuSoil_CuttingFurrows              },
            { E.Soil_Discing                     , RuSoil_Discing                     },
            { E.Soil_DustMulching                , RuSoil_DustMulching                },
            { E.Soil_Harrowing                   , RuSoil_Harrowing                   },
            { E.Soil_InrowCultivation            , RuSoil_InrowCultivation            },
            { E.Soil_LandClearingOfTreesAndBrush , RuSoil_LandClearingOfTreesAndBrush },
            { E.Soil_Other                       , RuSoil_Other                       },
            { E.Soil_Plowing                     , RuSoil_Plowing                     },
            { E.Soil_Pulling                     , RuSoil_Pulling                     },
            { E.Soil_Rolling                     , RuSoil_Rolling                     },
            { E.Soil_Slotting                    , RuSoil_Slotting                    },
            { E.Soil_Subsoiling                  , RuSoil_Subsoiling                  },
            { E.Transport_Chemicals              , RuTransport_Chemicals              },
            { E.Transport_Fertilizers            , RuTransport_Fertilizers            },
            { E.Transport_Food                   , RuTransport_Food                   },
            { E.Transport_Grain                  , RuTransport_Grain                  },
            { E.Transport_Machinery              , RuTransport_Machinery              },
            { E.Transport_Other                  , RuTransport_Other                  },
            { E.Transport_People                 , RuTransport_People                 },
            { E.Transport_Seeds                  , RuTransport_Seeds                  },
            { E.Transport_SpareParts             , RuTransport_SpareParts             },
            { E.Transport_Water                  , RuTransport_Water                  },
        };
    }
}
