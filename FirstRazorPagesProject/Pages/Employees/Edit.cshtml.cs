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
        [BindProperty]
        public Employee Employee { get; set; }
        [BindProperty]
        public IFormFile ?Photo { get; set; }

        [BindProperty]
        public bool Notify { get; set; }
        public string? Message{ get; set; }

        public IActionResult OnGet(int? id)
        {
            if(id.HasValue)
                Employee = _emloyeeRepository.GetEmployee(id.Value);
            else
                Employee = new Employee();

            if (Employee == null)
                return RedirectToPage("/NotFound");
            
            return Page();
        }
        public IActionResult OnPost() 
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (Employee.PhotoPath != null)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", Employee.PhotoPath);
                        System.IO.File.Delete(filePath);
                    }

                    Employee.PhotoPath = ProcessUploadedFiel();
                }
                if (Employee.Id > 0)
                {
                    Employee = _emloyeeRepository.Udate(Employee);
                    TempData["SeccessMessage"] = $"Udate {Employee.Name} successfull!";

                }
                else
                {
                    Employee = _emloyeeRepository.Add(Employee);
                    TempData["SeccessMessage"] = $"Adding {Employee.Name} successfull!";
                }
                return RedirectToPage("Employees");
            }
                return Page(); 
        }

        public void OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
                Message = "Thank you for turning on notifications";
            else
                Message = "You have torned off emailNotifications";
            
            Employee = _emloyeeRepository.GetEmployee(id);
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
