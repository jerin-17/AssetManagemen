using AssetManagementAPI.Model;
using AssetManagementConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Managers
{
    public class BuildingManager : IBuildingManager
    {
        private readonly IEntityManager<Building> _entityManager;
        private readonly IInputProvider<Building> _buildingManager;
        public BuildingManager(IInputProvider<Building> buildingInput, IEntityManager<Building> entityManager)
        {
            _entityManager = entityManager;
            _buildingManager = buildingInput;
        }
        public List<Building> GetBuildings()
        {
            return _entityManager.GetAll();
        }

        public Building GetBuildingById(int id)
        {
            return _entityManager.GetById(id);
        }
        public int OnboardBuilding()
        {
            var building = _buildingManager.GetInput();
            int id = _entityManager.Create(building);
            return id;
        }
    }
}
