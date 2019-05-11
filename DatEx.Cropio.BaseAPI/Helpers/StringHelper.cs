using System;
using System.Collections.Generic;
using System.Linq;

namespace DatEx.Cropio.BaseAPI
{
    public static class StringHelper
    {
        public static String F<T>(this ICollection<TimestamedValue<T>> collection)
        {
            if (collection == null || collection.Count == 0) return "—";
            return String.Format("{{Count: {0,4} ({1:yyyy.MM.dd HH.mm.ss} ... {2:yyyy.MM.dd HH.mm.ss})}}", collection.Count, collection.Min(x => x.TimeStamp), collection.Max(x => x.TimeStamp));
        }

        public static String F(this ICollection<TimeInverval> collection)
        {
            if(collection == null || collection.Count == 0)
                return "—";
            return String.Format("{{Count: {0,4} ({1:yyyy.MM.dd HH.mm.ss} ... {2:yyyy.MM.dd HH.mm.ss})}}", collection.Count, collection.Min(x => x.Begin), collection.Max(x => x.End));
        }

        public static String F(this Object obj, String dataFormating)
        {
            String formatString = "{0" + (String.IsNullOrEmpty(dataFormating) ? "" : ":") + dataFormating + "}";
            return String.Format(formatString, obj);
        }

        public static Int32 LinesCount(this String text)
        {
            return text.Length - text.Replace(Environment.NewLine, String.Empty).Length;
        }
    }
}