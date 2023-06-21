using System.ComponentModel.DataAnnotations;

namespace RazorPages.Models
{
    public class Employee
    {
        public  int Id { get; set; }
        [Required(ErrorMessage = "The name field can't be null! Please write, the name")]
        public  string? Name { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                           ErrorMessage = "Please, enter a Valid Email (format: example@outlook.com)")]
        public  string? Email { get; set; }
        public  string? PhotoPath { get; set; }
        public  Department? Department{ get; set; }
    }
}
