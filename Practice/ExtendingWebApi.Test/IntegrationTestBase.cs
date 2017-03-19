namespace ExtendingWebApi.Test
{
    using System.Net.Http;

    using Microsoft.Owin.Testing;

    using NUnit.Framework;

    public abstract class IntegrationTestBase
    {
        protected TestServer server;
        protected HttpClient client;

        [SetUp]
        public void SetUp()
        {
            server = TestServer.Create<StartUp>();
            client = new HttpClient(server.Handler);
        }

        [TearDown]
        public void TearDown()
        {
            client.Dispose();
            server.Dispose();
        }
    }
}