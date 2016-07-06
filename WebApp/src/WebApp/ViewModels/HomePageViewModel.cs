using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    using WebApp.Entities;

    public class HomePageViewModel
    {
        public IEnumerable<Student> Students { get; set; }

        public string CurrentGreeting { get; set; }
    }
}
