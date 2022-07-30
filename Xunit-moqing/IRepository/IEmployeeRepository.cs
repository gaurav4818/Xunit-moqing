using Xunit_moqing.Models;

namespace Xunit_moqing.IRepository
{
    public interface IEmployeeRepository 
    {
        Employee AddEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(Employee emp);
        Employee GetById(int empId);
        IEnumerable<Employee> GetAll();
    }
}
