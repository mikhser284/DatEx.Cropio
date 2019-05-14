using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatEx.Cropio.CUI
{
    public static class Ext_Linq
    {
        public static Dictionary<Int32, List<T>> ToDictionaryList<T>(this ICollection<T> collection, Func<T, Int32> keySelector)
        {
            Dictionary<Int32, List<T>> dict = new Dictionary<int, List<T>>();
            if(collection == null) return dict;
            foreach(T item in collection)
            {
                Int32 key = keySelector(item);
                if(dict.ContainsKey(key)) dict[key].Add(item);
                else dict.Add(key, new List<T>() { item });
            }
            return dict;
        }

        /// <summary> Получить элементы множества A которые не входят в множество B </summary>
        /// <typeparam name="TA"> Тип данных множества A </typeparam>
        /// <typeparam name="TB"> Тип данных множества B </typeparam>
        /// <param name="setA"> Множество A </param>
        /// <param name="setB"> Множество B </param>
        /// <param name="comparer"> Функция сравнения елементов </param>
        public static IEnumerable<TA> Except<TA, TB>(this IEnumerable<TA> setA, IEnumerable<TB> setB, Func<TA, TB, bool> comparer)
        {
            return setA.Where(x => setB.Count(y => comparer(x, y)) == 0);
        }

        /// <summary> Получить элементы множества A которые входят в множество B </summary>
        /// <typeparam name="TA"> Тип данных множества A </typeparam>
        /// <typeparam name="TB"> Тип данных множества B </typeparam>
        /// <param name="setA"> Множество A </param>
        /// <param name="setB"> Множество B </param>
        /// <param name="comparer"> Функция сравнения елементов </param>
        public static IEnumerable<TA> Intersect<TA, TB>(this IEnumerable<TA> setA, IEnumerable<TB> setB, Func<TA, TB, bool> comparer)
        {
            return setA.Where(x => setB.Count(y => comparer(x, y)) == 1);
        }

        /// <summary> Получить объединение двух множеств по указанному свойству </summary>
        /// <param name="setA"> Множество A </param>
        /// <param name="setB"> Множество B </param>
        /// <param name="keySelector"> Свойство по которому будет вестись выборка </param>
        /// <returns></returns>
        public static IEnumerable<TSource> UnionBy<TSource, TKey>(this IEnumerable<TSource> setA, IEnumerable<TSource> setB, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey> ();
            foreach(TSource element in setA)
                if(seenKeys.Add(keySelector(element)))
                    yield return element;
            foreach(TSource element in setB)
                if(seenKeys.Add(keySelector(element)))
                    yield return element;
        }

        /// <summary> Получить элементы множества у которых значение указанного свойства уникально </summary>
        /// <param name="source"> Исходное множество </param>
        /// <param name="keySelector"> Свойство по которому будет вестись выборка </param>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey> ();
            foreach(TSource element in source)
                if(element != null && seenKeys.Add(keySelector(element)))
                    yield return element;
        }

        public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            return source.MinBy(selector, null);
        }

        public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
        {
            if(source == null)
                throw new ArgumentNullException("source");
            if(selector == null)
                throw new ArgumentNullException("selector");
            comparer = comparer ?? Comparer<TKey>.Default;
            using(var sourceIterator = source.GetEnumerator())
            {
                if(!sourceIterator.MoveNext())
                {
                    throw new InvalidOperationException("Sequence contains no elements");
                }
                var min = sourceIterator.Current;
                var minKey = selector (min);
                while(sourceIterator.MoveNext())
                {
                    var candidate = sourceIterator.Current;
                    var candidateProjected = selector (candidate);
                    if(comparer.Compare(candidateProjected, minKey) < 0)
                    {
                        min = candidate;
                        minKey = candidateProjected;
                    }
                }
                return min;
            }
        }

        public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            return source.MaxBy(selector, null);
        }

        public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
        {
            if(source == null)
                throw new ArgumentNullException("source");
            if(selector == null)
                throw new ArgumentNullException("selector");
            comparer = comparer ?? Comparer<TKey>.Default;
            using(var sourceIterator = source.GetEnumerator())
            {
                if(!sourceIterator.MoveNext())
                {
                    throw new InvalidOperationException("Sequence contains no elements");
                }
                var max = sourceIterator.Current;
                var maxKey = selector (max);
                while(sourceIterator.MoveNext())
                {
                    var candidate = sourceIterator.Current;
                    var candidateProjected = selector (candidate);
                    if(comparer.Compare(candidateProjected, maxKey) > 0)
                    {
                        max = candidate;
                        maxKey = candidateProjected;
                    }
                }
                return max;
            }
        }
    }
}
