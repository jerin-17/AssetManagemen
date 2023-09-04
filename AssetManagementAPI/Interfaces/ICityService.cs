using AssetManagementAPI.DTO;
using AssetManagementAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementAPI.Interfaces
{
    public interface ICityService
    {
        List<City>  GetCities();
        int CreateCity(CityDTO city);
    }
}
