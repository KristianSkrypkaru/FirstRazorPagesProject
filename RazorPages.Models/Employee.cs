using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPages.Models
{
    public class Employee
    {
        public  int Id { get; set; }
        public  string Name { get; set; }
        public  string Email { get; set; }
        public  string PhotoPath { get; set; }
        public  Deprtment? Deprtment{ get; set; }
    }
}
