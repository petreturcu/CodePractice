namespace ExtendingWebApi
{
    using System.Web.Http;

    [RoutePrefix("")]
    public class AliveController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}