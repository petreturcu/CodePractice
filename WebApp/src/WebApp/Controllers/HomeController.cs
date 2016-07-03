using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    using WebApp.Models;

    public class HomeController : Controller
    {
        public ObjectResult Index()
        {
            var model = new Student {Id = 1, Name = "John Doe"};
            return new ObjectResult(model);
        }
    }
}
