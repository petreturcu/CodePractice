namespace ExtendingWebApi
{
    using System.Web.Http;

    using ExtendingWebApi.DelegatingHandlers;

    public static class DelegatingHandlersConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MessageHandlers.Add(new BasicAuthHandler());
        }
    }
}