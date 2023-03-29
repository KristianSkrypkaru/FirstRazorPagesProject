using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;

namespace FirstRazorPagesProject.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmloyeeRepository _emloyeeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(IEmloyeeRepository emloyeeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _emloyeeRepository = emloyeeRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public Employee Employee { get; set; }
        [BindProperty]
        public IFormFile Photo { get; set; }
        public IActionResult OnGet(int id)
        {
            Employee = _emloyeeRepository.GetEmployee(id);

            if (Employee == null)
                return RedirectToPage("/NotFound");
            
            return Page();
        }
        public IActionResult OnPost(Employee employee) 
        {
            if (Photo != null)
            {
                if (employee.PhotoPath != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", employee.PhotoPath);
                    System.IO.File.Delete(filePath);
                }

                employee.PhotoPath = ProcessUploadedFiel();
            }
            Employee = _emloyeeRepository.Udate(employee);
            return RedirectToPage("Employees");
        }

        private string ProcessUploadedFiel()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
