using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Samples.Tests.Core
{
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading.Tasks;

    using NUnit.Framework;

    [TestFixture]
    public class HttpClientUsageTests
    {
        [Test]
        public async Task AnyOperation_WhenPutInAUsing_IsConsiderablySlowerThanReusing()
        {
            // Arrange
            double timeWithUsing, timeWithReusable;
            Uri endpoint = new Uri("https://google.co.uk");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Act
            for (int i = 0; i < 100; i++)
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetStringAsync(endpoint);
                }
            }

            timeWithUsing = sw.Elapsed.TotalSeconds;

            sw.Restart();
            // Arrange
            using (HttpClient client = new HttpClient())
            {
                // Act
                for (int i = 0; i < 100; i++)
                {
                    var response = await client.GetStringAsync(endpoint);
                }
            }
            timeWithReusable = sw.Elapsed.TotalSeconds;

            // Assert
            Assert.Greater(timeWithUsing, timeWithReusable * 2);
        }

    }
}