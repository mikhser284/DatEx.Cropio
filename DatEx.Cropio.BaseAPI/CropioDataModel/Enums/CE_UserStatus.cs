using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using E = DatEx.Cropio.BaseAPI.CE_UserStatus;

namespace DatEx.Cropio.BaseAPI
{
    /// <summary> Статус пользователя </summary>
    public enum CE_UserStatus
    {
        /// <summary> Без доступа </summary>
        NoAccess = 1,
        /// <summary> Пользователь </summary>
        User = 2,
        /// <summary> Менеджер (только просмотр) </summary>
        ManagerReadOnly = 3,
        /// <summary> Менеджер </summary>
        Manager = 4,
        /// <summary> Администратор </summary>
        Admin = 5,
    }    

    public class JsonConverter_UserStatus : JsonConverter
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

    public static class EnumConverter_UserStatus
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
        




        private const String NoAccess           = "no_access";
        private const String User               = "user";
        private const String ManagerReadOnly    = "manager_read_only";
        private const String Manager            = "manager";
        private const String Admin              = "admin";


        private static readonly Dictionary<E, String> MapEnumToString = new Dictionary<E, String>
        {
            { E.NoAccess       , NoAccess        },
            { E.User           , User            },
            { E.ManagerReadOnly, ManagerReadOnly },
            { E.Manager        , Manager         },
            { E.Admin          , Admin           },
        };

        private static readonly Dictionary<String, E> MapStringToEnum = new Dictionary<String, E>
        {
            { NoAccess       , E.NoAccess        },
            { User           , E.User            },
            { ManagerReadOnly, E.ManagerReadOnly },
            { Manager        , E.Manager         },
            { Admin          , E.Admin           },
        };
    }
}
