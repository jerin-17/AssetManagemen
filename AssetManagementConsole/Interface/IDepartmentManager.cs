using AssetManagementAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Interface
{
    public interface IDepartmentManager
    {
        int CreateDepartment();
        List<Department> GetDepartments();
    }
}
