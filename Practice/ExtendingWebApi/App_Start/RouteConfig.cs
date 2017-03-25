namespace ExtendingWebApi
{
    using System.Web.Http;

    public static class RouteConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
        }
    }
}