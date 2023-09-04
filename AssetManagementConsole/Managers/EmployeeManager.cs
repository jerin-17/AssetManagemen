using AssetManagementAPI.DTO;
using AssetManagementAPI.Model;
using AssetManagementConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Managers
{
    public class EmployeeManager : IEmployeeManager
    {

        private readonly IInputProvider<List<EmployeeDTO>> _employeeInput;
        private readonly IEntityManager<EmployeeDTO> _entityManagerUpload;
        private readonly IEntityManager<Employee> _entityManager;

        public EmployeeManager(IInputProvider<List<EmployeeDTO>> employeeInput, IEntityManager<EmployeeDTO> entityManagerUpload, IEntityManager<Employee> entityManager)
        {
            this._employeeInput = employeeInput;
            this._entityManagerUpload = entityManagerUpload;
            this._entityManager = entityManager;
        }

        public List<int> CreateEmployee()
        {
            List<EmployeeDTO> employees = _employeeInput.GetInput();
            return _entityManagerUpload.CreateBatch(employees);
        }

        public List<Employee> GetEmployees()
        {
            return _entityManager.GetAll();
        }
    }
}
