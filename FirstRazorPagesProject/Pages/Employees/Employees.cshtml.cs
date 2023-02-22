using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Services;
using RazorPages.Models;

namespace FirstRazorPagesProject.Pages.Employees
{
    public class EmployeesModel : PageModel
    {
        private readonly IEmloyeeRepository _db;
        public EmployeesModel(IEmloyeeRepository db)
        {
            _db= db;
        }

        public IEnumerable<Employee> Employees{ get; set; }
        public void OnGet()
        {
            Employees = _db.GetAllEmployees();
        }
    }
}
