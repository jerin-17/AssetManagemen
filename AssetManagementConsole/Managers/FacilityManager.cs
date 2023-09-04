using AssetManagementAPI.Model;
using AssetManagementConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Managers
{
    public class FacilityManager : IFacilityManager
    {
        private readonly IInputProvider<Facility> _facilityInput;
        private readonly IEntityManager<Facility> _entityManager;

        public FacilityManager(IInputProvider<Facility> facilityInput,IEntityManager<Facility> entityManager)
        {
            this._facilityInput = facilityInput;
            this._entityManager = entityManager;
        }

        public int OnboardFacility()
        {
            Facility facility = _facilityInput.GetInput();
            _entityManager.Create(facility);
            return facility.FacilityId;
            
        }

        public List<Facility> GetFacilities()
        {
            return _entityManager.GetAll();
        }
    }
}
