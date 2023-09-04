using AssetManagementAPI.DTO;
using AssetManagementAPI.Interfaces;
using AssetManagementAPI.Model;

namespace AssetManagementAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employee)
        {
            this._employeeRepository = employee;
        }

        // create employee without saving it to the database
        /*private int CreateEmployeeWithoutSave(EmployeeDTO employee)
        {
          if(employee.EmployeeName == null)
            {
                throw new ArgumentNullException("Employee Name cannot be null");
            }
            var employeeNew = new Employee
            {
                EmployeeName = employee.EmployeeName,
                DepartmentId = employee.DepartmentId,
            };
            _employeeRepository.Add(employeeNew);
            return employeeNew.EmployeeId;
           
        }*/

        public int  CreateEmployee(EmployeeDTO employee)
        {
            if (employee.EmployeeName == null)
            {
                throw new ArgumentNullException("Employee Name cannot be null");
            }
            var employeeNew = new Employee
            {
                EmployeeName = employee.EmployeeName,
                DepartmentId = employee.DepartmentId,
            };
            _employeeRepository.Add(employeeNew);
            _employeeRepository.Save();
            return employeeNew.EmployeeId;
        }


        public List<int> CreateEmployeeBatch(List<EmployeeDTO> employees)
        {
            List<int> employeeIds = new List<int>();
           foreach(var employee in employees)
            {
                employeeIds.Add(CreateEmployee(employee));
            }

            return employeeIds;
            
        }

        public void EditEmployee(Employee employee)
        {
            var employeeForUpdate = _employeeRepository.GetAll().FirstOrDefault( a => a.EmployeeId == employee.EmployeeId );
            employeeForUpdate.EmployeeName = employee.EmployeeName;
            employeeForUpdate.IsAllocated = employee.IsAllocated; 
            employeeForUpdate.DepartmentId = employee.DepartmentId;
        }

        public List<Employee> GetEmployees()
        {
            return _employeeRepository.GetAll().ToList();
        }
    }
}
