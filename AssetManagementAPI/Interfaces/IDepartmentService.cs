using AssetManagementAPI.DTO;
using AssetManagementAPI.Model;

namespace AssetManagementAPI.Interfaces
{
    public interface IDepartmentService
    {
        List<Department> GetDepartments();
        int CreateDepartment(DepartmentDTO department);
    }
}
