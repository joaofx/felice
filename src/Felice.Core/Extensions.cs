namespace Felice.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class Extensions
    {
        public static string Show(this DateTime value)
        {
            return value.ToString("dd/MM/yyyy");
        }

        public static string ShowAsPercentage(this decimal value)
        {
            return string.Format("{0:P2}", value);
        }

        public static string Show(this decimal value)
        {
            //// TODO: http://cbsa.com.br/post/usar-globalization-no-webconfig-e-cultureinfo-para-formatar-data-e-moeda-em-varios-idiomas-no-aspnet-c.aspx
            return string.Format("{0:C}", value);
        }

        public static decimal ToDecimal2(this string value)
        {
            return string.IsNullOrEmpty((string) value) ? 0 : Convert.ToDecimal(value);
        }

        public static int ToInt(this string value)
        {
            return string.IsNullOrEmpty(value) ? 0 : Convert.ToInt32(value);
        }

        public static long ToLong(this string value)
        {
            return string.IsNullOrEmpty(value) ? 0 : Convert.ToInt64(value);
        }

        public static DateTime ToDateTime(this string value)
        {
            return string.IsNullOrEmpty(value) ? DateTime.MinValue : Convert.ToDateTime(value);
        }

        public static string Subtext(this string value, int startPosition, int finalPosition)
        {
            return value.Substring(startPosition - 1, finalPosition - startPosition - 1);
        }

        public static string PascalToSentence(this string value)
        {
            return Regex.Replace(value, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 ");
        }

        public static IList<IList<T>> SplitInGroupsOf<T>(this IList<T> source, int itemsPerList)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / itemsPerList)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToArray();
        }

        public static ReadOnlyCollection<T> AsReadOnly<T>(this IList<T> list)
        {
            return ((List<T>) list).AsReadOnly();
        }

        public static decimal Negative(this decimal value)
        {
            if (value > 0)
            {
                return value * -1;
            }

            return value;
        }

        public static decimal Positive(this decimal value)
        {
            if (value < 0)
            {
                return value * -1;
            }

            return value;
        }
    }
}
