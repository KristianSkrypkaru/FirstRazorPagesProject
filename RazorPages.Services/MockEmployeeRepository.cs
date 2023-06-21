using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPages.Services
{
    public class MockEmployeeRepository : IEmloyeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee()
                {
                    Id = 1, Name = "John", Email = "john@example.com", PhotoPath = "avatar1.png", Department = Department.HR
                },
                new Employee()
                {
                    Id = 2, Name = "Karl", Email = "karl@example.com", PhotoPath = "avatar2.png", Department = Department.IT
                },
                new Employee()
                {
                    Id = 3, Name = "Tomas", Email = "tomas@example.com", PhotoPath = "avatar3.png", Department = Department.HR
                },
                new Employee()
                {
                    Id = 4, Name = "Bastian", Email = "bastian@example.com", PhotoPath = "avatar4.png", Department = Department.Payroll
                },
                new Employee()
                {
                    Id = 5, Name = "Manuel", Email = "manuel@example.com", PhotoPath = "avatar5.png", Department = Department.IT
                },
                new Employee()
                {
                    Id = 6, Name = "Justin", Email = "justinl@example.com", Department = Department.IT
                }
            };
        }

        public Employee Add(Employee newEmployee)
        {
            newEmployee.Id = _employeeList.Max(x => x.Id) + 1;
            _employeeList.Add(newEmployee);
            return newEmployee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(x => x.Id == id);
        }

        public Employee Udate(Employee udatedEmployee)
        {
            Employee employee = _employeeList.FirstOrDefault(x => x.Id == udatedEmployee.Id);
            
            if (employee != null)
            {
                employee.Name = udatedEmployee.Name;
                employee.Email = udatedEmployee.Email;
                employee.Department = udatedEmployee.Department;
                employee.PhotoPath = udatedEmployee.PhotoPath;
            }
            return employee;
        }
    }
}
