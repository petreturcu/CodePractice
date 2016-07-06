using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    using WebApp.Entities;

    public interface IStudentData
    {
        IEnumerable<Student> GetAll();
        Student Get(int id);

        void Add(Student newStudent);
    }

    public class InMemoryStudentData : IStudentData
    {
        static List<Student> _students;

        static InMemoryStudentData()
        {
            _students = new List<Student>
            {
                new Student {Id = 1, Name = "Allan" },
                new Student {Id = 2, Name = "Sonja" },
                new Student {Id = 3, Name = "Alexandra" }
            };
        }

        public void Add(Student newStudent)
        {
            newStudent.Id = _students.Max(s => s.Id) + 1;
            _students.Add(newStudent);
        }

        public Student Get(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _students;
        }
    }
}
