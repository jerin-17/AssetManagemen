using AssetManagementAPI.DTO;
using AssetManagementAPI.Interfaces;
using AssetManagementAPI.Model;
using Microsoft.EntityFrameworkCore;
using AssetManagementAPI.MyExceptions;
using AssetManagementAPI.Utility;

namespace AssetManagementAPI.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IRepository<Building> _buildingRepository;

        public BuildingService(IRepository<Building> buildingRepository)
        {
            this._buildingRepository = buildingRepository;
        }

        public List<Building> GetBuildings()
        {
            return _buildingRepository.GetAll().ToList();
        }



        public int CreateBuilding(BuildingDTO building)
        {
            if (building.BuildingAbbr == null)
            {
                throw new ArgumentNullException ("City Abbreviation cannot be null");
            }
            if (building.BuildingName == null)
            {
                throw new ArgumentNullException ("City Name cannot be null");
            }
            var validator = new AbbrValidator<Building>(GetBuildings());
            validator.ValidateAbbr(building.BuildingAbbr, Building => Building.BuildingAbbr);
            var buildingNew = new Building
            {
                BuildingName = building.BuildingName,
                BuildingAbbr = building.BuildingAbbr.ToUpper()
            };
            _buildingRepository.Add(buildingNew);
            _buildingRepository.Save();
            return (buildingNew.BuildingId);
        }
    }
}
