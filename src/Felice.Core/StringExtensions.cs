namespace Felice.Core
{
    public static class StringExtensions
    {
        public static string Right(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return value.Substring(value.Length - 1);
        }

        public static bool IsEqual(this string value, params string[] valuesToCompare)
        {
            foreach (var valueToCompare in valuesToCompare)
            {
                if (value.Equals(valueToCompare))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
