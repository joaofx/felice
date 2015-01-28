namespace Felice.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumerableExtensions
    {
        public static string Join<T>(this IEnumerable<T> enumerable, string split)
        {
            return enumerable.Join(split, x => x.ToString());
        }

        public static string Join<T>(this IEnumerable<T> enumerable, string split, Func<T, string> action)
        {
            return enumerable
                .Aggregate(string.Empty, (current, item) => current + (action(item) + split))
                .TrimEnd(split.ToCharArray());
        }

        public static IEnumerable<T[]> EachSlice<T>(this IEnumerable<T> xs, int size)
        {
            return xs.Select((x, i) => new { x, i })
                     .GroupBy(xi => xi.i / size, xi => xi.x)
                     .Select(g => g.ToArray());
        }
    }
}
