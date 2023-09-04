using AssetManagementAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Interface
{
    public interface IBuildingManager
    {
        List<Building> GetBuildings();
        Building GetBuildingById(int id);
        int OnboardBuilding();
    }
}
