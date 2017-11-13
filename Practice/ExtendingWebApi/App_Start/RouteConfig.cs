namespace ExtendingWebApi
{
    using System.Web.Http;

    public static class RouteConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "API Default",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { controller = "alive", action = "get" }
            );
        }
    }
}