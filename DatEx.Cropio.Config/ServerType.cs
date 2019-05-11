using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using E = DatEx.Cropio.Config.ServerType;

namespace DatEx.Cropio.Config
{
    public enum ServerType
    {
        Development = 1,
        Staging = 2,
        Productive = 3
    }
}

public class JsonConverter_ServerType : JsonConverter
{
    public override Boolean CanConvert(Type objectType)
    {
        return objectType == typeof(E);
    }

    public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return default(E?);
        JToken token = JToken.Load(reader);
        E enumValue;
        token.Value<String>().AsEnum(out enumValue);
        return enumValue;
    }

    public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
    {
        if (value.GetType() != typeof(E)) throw new InvalidOperationException();
        writer.WriteValue(((E)value).AsString());
    }
}

public static class EnumConverter_ServerType
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

    private const String Development = "Development";
    private const String Staging = "Staging";
    private const String Productive = "Productive";

    private static readonly Dictionary<E, String> MapEnumToString = new Dictionary<E, String>
        {
            { E.Development, Development },
            { E.Staging,     Staging     },
            { E.Productive,  Productive  },
        };

    private static readonly Dictionary<String, E> MapStringToEnum = new Dictionary<String, E>
        {
            { Development, E.Development      },
            { Staging,     E.Staging   },
            { Productive,  E.Productive },
        };
}
