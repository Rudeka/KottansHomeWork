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

        static IEnumerable<TResult> Iterator<TSource, TResult>(IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            foreach (TSource element in source)
            {
                yield return selector(element);
            }
        }

        static IEnumerable<TResult> Iterator <TSource, TResult> (IEnumerable<TSource> source,
            Func<TSource,int, TResult> selector)
        {
            int index = 0;
            foreach (TSource element in source)
            {
                yield return selector(element, index++);
            }
        }
    }
}