using AssetManagementAPI.DTO;
using AssetManagementAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementAPI.Interfaces
{
    public interface IBuildingService
    {
        List<Building> GetBuildings();
        int CreateBuilding(BuildingDTO city);
    }
}
