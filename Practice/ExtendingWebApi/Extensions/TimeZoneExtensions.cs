namespace ExtendingWebApi.Extensions
{
    using System;
    using System.Reflection;

    public static class TimeZoneExtensions
    {
        public static bool IsRelevantTo(this TimeZoneInfo timeZone, string term)
        {
            foreach (PropertyInfo property in timeZone.GetPropsOfType<string>())
            {
                if ((timeZone.GetPropValue(property) as string).Contains(term, StringComparison.OrdinalIgnoreCase)) return true;
            }

            return false;
        }
    }
}