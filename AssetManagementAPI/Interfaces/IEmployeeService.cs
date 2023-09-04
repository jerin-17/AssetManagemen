using AssetManagementAPI.DTO;
using AssetManagementAPI.Model;

namespace AssetManagementAPI.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        int CreateEmployee(EmployeeDTO employee);
        List<int> CreateEmployeeBatch(List<EmployeeDTO> employees);

    }
}
