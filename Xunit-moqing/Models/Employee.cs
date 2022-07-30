using System.ComponentModel.DataAnnotations;

namespace Xunit_moqing.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [StringLength(50)]
        public string EmployeeName { get; set; }
        public int EmployeeCode { get; set; }
        public string EmployeeCity { get; set; }
        public decimal Salary { get; set; }

    }
}
