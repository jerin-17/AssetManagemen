using AssetManagementAPI.DTO;
using AssetManagementAPI.Interfaces;
using AssetManagementAPI.Model;
using AssetManagementAPI.MyExceptions;

namespace AssetManagementAPI.Services
{
    public class CabinService : ICabinService
    {
        private readonly IRepository<Cabin> _cabinRepository;
        private readonly IRepository<Employee> _employeeRepository;

        public CabinService(IRepository<Cabin> cabinRepository, IRepository<Employee> employeeRepository)

        {
            this._cabinRepository = cabinRepository;
            this._employeeRepository = employeeRepository;
        }

        public List<Cabin> GetCabins()
        {
            return _cabinRepository.GetAll().ToList();
        }

        public int CreateCabin(CabinDTO cabin)
        {
            if (cabin.CabinNumber == null)
            {
                throw new ArgumentNullException("Seat Number cannot be Null");
            }

            var cabinNew = new Cabin
            {
                CabinNumber = cabin.CabinNumber,
                FacilityId = cabin.FacilityId
            };
            _cabinRepository.Add(cabinNew);
            _cabinRepository.Save();
            return cabinNew.CabinId;
        }

        public void AllocateCabin(int cabinId, int employeeId)
        {
            Cabin cabin = _cabinRepository.GetById(cabinId);
            if (cabin.EmployeeId != null)
            {
                throw new DataExistsException("Seat is already allocated");
            }
            cabin.EmployeeId = employeeId;
            _employeeRepository.GetById(employeeId).IsAllocated = true;
            _cabinRepository.Update(cabin);
            _cabinRepository.Save();
            _employeeRepository.Save();
        }

        public void DeallocateCabin(int cabinId)
        {
            Cabin cabin = _cabinRepository.GetById(cabinId);
            if (cabin.EmployeeId == null)
            {
                throw new ArgumentNullException("Seat is not allocated");
            }
            _employeeRepository.GetById((int)cabin.EmployeeId).IsAllocated = false;
            cabin.EmployeeId = null;
            _cabinRepository.Update(cabin);
            _cabinRepository.Save();
            _employeeRepository.Save();
        }
    }

}

