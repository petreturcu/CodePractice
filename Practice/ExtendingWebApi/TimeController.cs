namespace ExtendingWebApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;

    using ExtendingWebApi.Extensions;
    using ExtendingWebApi.Models;

    public class TimeController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get([FromUri]string term = null)
        {
            var req = Request;

            string termm = req.GetQueryNameValuePairs().FirstOrDefault(q => String.Compare(q.Key, "term", StringComparison.OrdinalIgnoreCase) == 0).Value;

            // Get request body
            dynamic data = await req.Content.ReadAsAsync<object>();

            List<TimeZoneTime> times = new List<TimeZoneTime>();
            if (string.IsNullOrWhiteSpace(term))
            {
                foreach (TimeZoneInfo timeZone in TimeZoneInfo.GetSystemTimeZones())
                {
                    times.Add(new TimeZoneTime(timeZone, GetTimeFor(timeZone)));
                }
            }
            else
            {
                try
                {
                    TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(term);
                    times.Add(new TimeZoneTime(timeZoneInfo, GetTimeFor(timeZoneInfo)));
                }
                catch (TimeZoneNotFoundException)
                {
                    foreach (TimeZoneInfo timeZone in GetRelevantTimeZones(term))
                    {
                        times.Add(new TimeZoneTime(timeZone, GetTimeFor(timeZone)));
                    }
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, times);
        }

        private static List<TimeZoneInfo> GetRelevantTimeZones(string term)
        {
            List<TimeZoneInfo> timeZones = new List<TimeZoneInfo>();
            foreach (TimeZoneInfo timeZone in TimeZoneInfo.GetSystemTimeZones())
            {
                if (timeZone.IsRelevantTo(term))
                    timeZones.Add(timeZone);
            }

            return timeZones;
        }

        private static DateTimeOffset GetTimeFor(TimeZoneInfo info)
        {
            DateTimeOffset localServerTime = DateTimeOffset.Now;
            return TimeZoneInfo.ConvertTime(localServerTime, info);
        }
    }
}