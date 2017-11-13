namespace ExtendingWebApi.Models
{
    using System;

    public class TimeZoneTime
    {
        public TimeZoneInfo TimeZone { get; }

        public DateTimeOffset DateTime { get; }

        public TimeZoneTime(TimeZoneInfo timeZone, DateTimeOffset dateTime)
        {
            TimeZone = timeZone;
            DateTime = dateTime;
        }
    }
}