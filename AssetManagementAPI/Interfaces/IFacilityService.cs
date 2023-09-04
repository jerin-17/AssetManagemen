using AssetManagementAPI.DTO;
using AssetManagementAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementAPI.Interfaces
{
    public interface IFacilityService
    {
        List<Model.Facility> GetFacilities();
        int CreateFacility(FacilityDTO facility);
    }
}
