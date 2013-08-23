namespace Felice.Core
{
    using System.Text.RegularExpressions;

    public class StringHelper
    {
        public static string ToLowerUnderscored(string value)
        {
            return Regex.Replace(
                value,
                @"([A-Z])([A-Z][a-z])|([a-z0-9])([A-Z])",
                "$1$3_$2$4").ToLower();
        }
    }
}
