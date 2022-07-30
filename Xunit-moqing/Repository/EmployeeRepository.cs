using Microsoft.EntityFrameworkCore;
using Xunit_moqing.IRepository;
using Xunit_moqing.Models;

namespace Xunit_moqing.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;
        public EmployeeRepository(EmployeeContext context)
        {
           this._context = context;
        }
        public Employee AddEmployee(Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
            var result = _context.Employees.OrderByDescending(x => x.EmployeeId).FirstOrDefault();
            return result;
        }

        public void DeleteEmployee(Employee emp)
        {
            _context.Employees.Remove(emp);
            _context.Entry(emp).State = EntityState.Deleted;
            _context.SaveChanges(true);
        }

        public IEnumerable<Employee> GetAll()
        {
            var result = _context.Employees.AsEnumerable();
            return result;
        }

        public Employee GetById(int empId)
        {
            var result = _context.Employees.FirstOrDefault(x=> x.EmployeeId == empId);
            return result;
        }

        public void UpdateEmployee(Employee emp)
        {
            var result = GetById(emp.EmployeeId);
            if(result != null)
            {
                _context.Employees.Update(emp);
                _context.Entry(emp).State= EntityState.Modified;
                _context.SaveChanges();
            }
            
        }
    }
}
