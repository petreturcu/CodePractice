using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    using Services;
    using WebApp.Models;

    public class HomeController : Controller
    {
        private IStudentData _studentData;

        public HomeController(IStudentData studentData)
        {
            _studentData = studentData;
        }

        public ViewResult Index()
        {
            var model = _studentData.GetAll();
            return View(model);
        }
    }
}
