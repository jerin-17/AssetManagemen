using AssetManagementAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Interface
{
    public interface IFacilityManager
    {
        int OnboardFacility();
        List<Facility> GetFacilities();
    }
}
