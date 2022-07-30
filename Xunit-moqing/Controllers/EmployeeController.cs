using Microsoft.AspNetCore.Mvc;
using Xunit_moqing.IRepository;
using Xunit_moqing.Models;

namespace Xunit_moqing.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }
        public List<Employee> GetAll()
        {
            return _employeeRepository.GetAll().ToList();
        }
        public Employee AddEmployee(Employee employee)
        {
            var result =_employeeRepository.AddEmployee(employee);
            return result;
        }
        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.UpdateEmployee(employee);
        }
        public void DeleteEmployee(Employee employee)
        {
            _employeeRepository.DeleteEmployee(employee);
        }
        public decimal TotalSalary()
        {
            var result = _employeeRepository.GetAll();
            var totalSalary = result.Sum(x=> x.Salary);
            return totalSalary;
        }
    }
}
