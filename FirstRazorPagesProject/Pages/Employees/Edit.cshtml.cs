using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;

namespace FirstRazorPagesProject.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmloyeeRepository _emloyeeRepository;

        public EditModel(IEmloyeeRepository emloyeeRepository)
        {
            _emloyeeRepository = emloyeeRepository;

        }
        public Employee Employee { get; set; }  
        public IActionResult OnGet(int id)
        {
            Employee = _emloyeeRepository.GetEmployee(id);

            if (Employee == null)
                return RedirectToPage("/NotFound");
            return Page();
        }
    }
}
