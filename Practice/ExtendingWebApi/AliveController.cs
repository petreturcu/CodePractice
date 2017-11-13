namespace ExtendingWebApi
{
    using System.Net.Http;
    using System.Web.Http;

    public class AliveController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {

            return Ok();
        }
    }
}