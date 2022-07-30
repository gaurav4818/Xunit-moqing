using Moq;
using System.Collections.Generic;
using Xunit;
using Xunit_moqing.Controllers;
using Xunit_moqing.IRepository;
using Xunit_moqing.Models;

namespace xunit_moq_demo
{
    public class MoqingTest
    {
        private readonly Mock<IEmployeeRepository> repo;
        public MoqingTest()
        {
            repo = new Mock<IEmployeeRepository>();
        }

        [Theory(DisplayName ="GetEmployeeByIdTest")]
        [InlineData(1)]
        public void GetEmployeeById_ReturnsEmployee(int id)
        {
            //Arrange
            var employee = new Employee() {EmployeeId=1, EmployeeName = "aaa", EmployeeCode = 2031, Salary = 30000, EmployeeCity = "demo" };
            repo.Setup(x=> x.GetById(id)).Returns(employee);
            var controller = new EmployeeController(repo.Object);
            //Act
            var result = controller.GetById(id);
            var actual = result as Employee;
            //Assert
            Assert.IsType<Employee>(actual);
            Assert.Equal(employee.EmployeeId, actual.EmployeeId);
            Assert.Equal(employee.EmployeeCode, actual.EmployeeCode);
            Assert.Equal(employee, result);
        }

        [Fact(DisplayName = "GelAllEmployee")]
        public void GetAllEmployee_ReturnsEmployees()
        {
            //Arrange
            List<Employee> employees = new List<Employee>() {
             new Employee() { EmployeeId = 1, EmployeeName = "aaa", EmployeeCode = 2031, Salary = 30000, EmployeeCity = "demo" },
             new Employee() { EmployeeId = 2, EmployeeName = "bbb", EmployeeCode = 2032, Salary = 32000, EmployeeCity = "demo1" },
            };
                new Employee() { EmployeeId = 1, EmployeeName = "aaa", EmployeeCode = 2031, Salary = 30000, EmployeeCity = "demo" };
            repo.Setup(x => x.GetAll()).Returns(employees);
            var controller = new EmployeeController(repo.Object);
            //Act
            var result = controller.GetAll();
            var actual = result as List<Employee>;
            //Assert
            Assert.IsType<List<Employee>>(actual);
            Assert.Equal(employees, result);
        }

        [Fact(DisplayName = "AddEmployee")]
        public void AddEmployee_ReturnsEmployee()
        {
            //Arrange
            var employee = new Employee() {EmployeeId=6,EmployeeName = "ooo", EmployeeCode = 2099, Salary = 50000, EmployeeCity = "newDemo" };
            repo.Setup(x => x.AddEmployee(employee)).Returns(employee);
            var controller = new EmployeeController(repo.Object);
            //Act
            var result = controller.AddEmployee(employee);
            var actual = result as Employee;
            //Assert
            Assert.IsType<Employee>(actual);
            Assert.Equal(6,actual.EmployeeId);
           
        }

        [Theory(DisplayName = "FindTotalSalary")]
        [InlineData(67000.00)]
        public void FindTotalSalary_ReturnsTotalSalaryOfEmployees(decimal totalSalary)
        {
            //Arrange
            List<Employee> employees = new List<Employee>() {
             new Employee() { EmployeeId = 1, EmployeeName = "aaa", EmployeeCode = 2031, Salary = 30000, EmployeeCity = "demo" },
             new Employee() { EmployeeId = 2, EmployeeName = "bbb", EmployeeCode = 2032, Salary = 32000, EmployeeCity = "demo1" },
             new Employee() { EmployeeId = 6, EmployeeName = "ooo", EmployeeCode = 2099, Salary = 5000, EmployeeCity = "newDemo" }
            };
            new Employee() { EmployeeId = 1, EmployeeName = "aaa", EmployeeCode = 2031, Salary = 30000, EmployeeCity = "demo" };
            repo.Setup(x => x.GetAll()).Returns(employees);
            var controller = new EmployeeController(repo.Object);
            //Act
            var result = controller.TotalSalary();
            var actual = result;
            //Assert
            Assert.IsType<decimal>(actual);
            Assert.Equal(totalSalary, actual);

        }
    }
}