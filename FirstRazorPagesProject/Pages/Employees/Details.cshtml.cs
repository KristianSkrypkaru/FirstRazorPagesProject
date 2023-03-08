using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;

namespace FirstRazorPagesProject.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly IEmloyeeRepository _emloyeeRepository;

        public DetailsModel(IEmloyeeRepository emloyeeRepository)
        {
            _emloyeeRepository = emloyeeRepository;
        }

        public Employee Employee { get; private set; }

        public void OnGet(int id)
        {
            Employee = _emloyeeRepository.GetEmployee(id);
        }
    }
}
