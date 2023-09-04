using AssetManagementAPI.Model;
using AssetManagementConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Managers
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IInputProvider<Department> _departmentInput;
        private readonly IEntityManager<Department> _entityManager;

        public DepartmentManager(IInputProvider<Department> departmentInput,IEntityManager<Department> entityManager) {
            this._departmentInput = departmentInput;
            this._entityManager = entityManager;
        }

        public int CreateDepartment()
        {
            Department department = _departmentInput.GetInput();
            return _entityManager.Create(department);
        }

        public List<Department> GetDepartments()
        {
            return _entityManager.GetAll(); 
        }
    }
}
