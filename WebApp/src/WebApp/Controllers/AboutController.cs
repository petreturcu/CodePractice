using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("company/[controller]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "+07444444444";
        }

        [Route("[action]")]
        public string Country()
        {
            return "UK";
        }
    }
}
