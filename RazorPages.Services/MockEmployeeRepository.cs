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
                    Id = 1, Name = "John", Email = "john@example.com", PhotoPath = "ava.png", Deprtment = Deprtment.HR
                },
                new Employee()
                {
                    Id = 2, Name = "Karl", Email = "karl@example.com", PhotoPath = "ava1.png", Deprtment = Deprtment.IT
                },
                new Employee()
                {
                    Id = 3, Name = "Tomas", Email = "tomas@example.com", PhotoPath = "ava1.png", Deprtment = Deprtment.HR
                },
                new Employee()
                {
                    Id = 4, Name = "Bastian", Email = "bastian@example.com", PhotoPath = "ava1.png", Deprtment = Deprtment.Payroll
                },
                new Employee()
                {
                    Id = 5, Name = "Manuel", Email = "manuel@example.com", PhotoPath = "ava1.png", Deprtment = Deprtment.IT
                },
                new Employee()
                {
                    Id = 6, Name = "Justin", Email = "justinl@example.com", Deprtment = Deprtment.IT
                }
            };
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(x => x.Id == id);
        }
    }
}
