using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementAPI.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public bool IsAllocated { get; set; }
        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
