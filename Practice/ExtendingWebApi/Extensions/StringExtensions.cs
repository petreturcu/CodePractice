namespace ExtendingWebApi.Extensions
{
    using System;

    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            if (string.IsNullOrWhiteSpace(toCheck) || string.IsNullOrWhiteSpace(source))
                return true;

            return source.IndexOf(toCheck, comp) >= 0;
        }
    }
}