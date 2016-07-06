using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    using WebApp.Services;
    using WebApp.ViewModels;
    using WebApp.Entities;

    public class HomeController : Controller
    {
        private IStudentData _studentData;
        private IGreeter _greeter;

        public HomeController(IStudentData studentData, IGreeter greeter)
        {
            _studentData = studentData;
            _greeter = greeter;
        }

        public ViewResult Index()
        {
            var model = new HomePageViewModel
            {
                Students = this._studentData.GetAll(),
                CurrentGreeting = this._greeter.GetGreeting()
            };
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentEditViewModel model)
        {
            var student = new Student
            {
                Name = model.Name,
                Personality = model.Personality
            };

            _studentData.Add(student);

            return RedirectToAction("Details", new { id = student.Id });
        }


        public IActionResult Details(int id)
        {
            var model = _studentData.Get(id);

            if (model == null)
                return RedirectToAction("Index");

            return View(model);
        }
    }
}
