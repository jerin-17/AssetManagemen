using AssetManagementAPI.DTO;
using AssetManagementAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Interface
{
    public interface IEmployeeManager
    {
        List<int> CreateEmployee();
        List<Employee> GetEmployees();
    }
}
