using System.ComponentModel.DataAnnotations;
using WebApp.Entities;

namespace WebApp.ViewModels
{
    public class StudentEditViewModel
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public Hobby Hobby { get; set; }
    }
}
