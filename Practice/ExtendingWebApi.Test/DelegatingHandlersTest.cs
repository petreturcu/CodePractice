namespace ExtendingWebApi.Test
{
    using System;
    using System.Net;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Web.Http.Results;

    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class DelegatingHandlersTest : IntegrationTestBase
    {
        [Test]
        public async Task AuthDelegatingHandler_RequestHasBasic_ShouldReturnOk()
        {
            // Arrange
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "parameter");

            // Act
            var response = await client.GetAsync("http://localhost:15498");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public async Task AuthDelegatingHandler_RequestNOBasic_ShouldReturnUnauthorized()
        {
            // Arrange

            // Act
            var response = await client.GetAsync("http://localhost:15498");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}