using AssetManagementAPI.DTO;
using AssetManagementAPI.Interfaces;
using AssetManagementAPI.Model;
using AssetManagementAPI.Utility;

namespace AssetManagementAPI.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentService(IRepository<Department> departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }

        public List<Department> GetDepartments()
        {
            return _departmentRepository.GetAll().ToList();
        }



        public int CreateDepartment(DepartmentDTO department)
        {
            if (department.DepartmentName == null)
            {
                throw new ArgumentNullException("City Abbreviation cannot be null");
            }

            var departmentNew = new Department
            {
                DepartmentName = department.DepartmentName,
            };
            _departmentRepository.Add(departmentNew);
            _departmentRepository.Save();
            return (departmentNew.DepartmentId);
        }
    }
}

