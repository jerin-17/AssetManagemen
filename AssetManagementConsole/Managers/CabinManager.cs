using AssetManagementAPI.Model;
using AssetManagementConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Managers
{
    public class CabinManager : ICabinManager
    {
        private readonly IInputProvider<Cabin> __cabinInput;
        private readonly IEntityManager<Cabin> _entityManager;

        public CabinManager(IInputProvider<Cabin> cabinInput, IEntityManager<Cabin> entityManager)
        {
            this.__cabinInput = cabinInput;
            this._entityManager = entityManager;
        }

        public int OnboardCabin()
        {
            Cabin cabin = __cabinInput.GetInput();
            _entityManager.Create(cabin);
            return cabin.FacilityId;

        }

        public List<Cabin> GetCabins()
        {
            return _entityManager.GetAll();
        }
    }
}
