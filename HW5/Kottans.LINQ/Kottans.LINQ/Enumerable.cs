using System;
using System.Collections;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class Enumerable
    {
        public static IEnumerable<TResult> Select<TSource, TResult>
            (this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException();
            if (selector == null) throw new ArgumentNullException();

            return Iterator(source, selector);
        }

        public static IEnumerable<TResult> Select<TSource, TResult>
            (this IEnumerable<TSource> source,
            Func<TSource, int, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException();
            if (selector == null) throw new ArgumentNullException();

            return Iterator(source, selector);
        }

        public static IEnumerable<TSource> Where<TSource>
            (this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            return Iterator(source, predicate);
        }

        public static IEnumerable<TSource> Where<TSource>
           (this IEnumerable<TSource> source,
           Func<TSource, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            return Iterator(source, predicate);
        }

        public static TSource FirstOrDefault<TSource>
            (this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException();

            foreach (var element in source)
            {
                return element;
            }
            return default(TSource);
        }

        public static TSource FirstOrDefault<TSource>
            (this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            foreach (var element in source)
            {
                if (predicate(element))
                    return element;
            }
            return default(TSource);
        }

        public static IEnumerable<int> Range(int start, int count)
        {
            var list = new List<int>();
            for (var i = 0; i < count; i++)
            {
                list.Add(start);
                start++;
            }
            return list;
        }

        public static int Count <TSource> (this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException();

            int count = 0;
            foreach (var element in source)
            {
                count++;
            }
            return count;
        }

        public static int Count<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            int count = 0;
            foreach (var element in source)
            {
                if (predicate(element))
                    count++;
            }
            return count;
        }

        static IEnumerable<TResult> Iterator<TSource, TResult>(IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            foreach (var element in source)
            {
                yield return selector(element);
            }
        }

        static IEnumerable<TResult> Iterator<TSource, TResult>(IEnumerable<TSource> source,
            Func<TSource, int, TResult> selector)
        {
            var index = 0;
            foreach (var element in source)
            {
                yield return selector(element, index++);
            }
        }

        static IEnumerable<TSource> Iterator<TSource>(IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            foreach (var element in source)
            {
                if (predicate(element))
                    yield return element;
            }
        }
        static IEnumerable<TSource> Iterator<TSource>(IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            var index = 0;
            foreach (var element in source)
            {
                if (predicate(element, index))
                    yield return element;
                index++;
            }
        }

    }
}