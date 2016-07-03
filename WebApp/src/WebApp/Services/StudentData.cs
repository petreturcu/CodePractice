using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IStudentData
    {
        IEnumerable<Student> GetAll();
    }

    public class InMemoryStudentData : IStudentData
    {
        List<Student> _students;

        public InMemoryStudentData()
        {
            _students = new List<Student>
            {
                new Student {Id = 1, Name = "Allan" },
                new Student {Id = 2, Name = "Sonja" },
                new Student {Id = 3, Name = "Alexandra" }
            };
        }

        public IEnumerable<Student> GetAll()
        {
            return _students;
        }
    }
}
