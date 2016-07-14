using System.ComponentModel.DataAnnotations;

namespace WebApp.Entities
{
    public enum Hobby
    {
        Football,
        Photography,
        Gym,
        Reading
    }

    public class Student
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        [Display(Name="Student Name")]
        public string Name { get; set; }

        public Hobby Hobby { get; set; }
    }
}