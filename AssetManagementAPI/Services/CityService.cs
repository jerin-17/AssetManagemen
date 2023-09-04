using AssetManagementAPI.DTO;
using AssetManagementAPI.Interfaces;
using AssetManagementAPI.Model;
using AssetManagementAPI.MyExceptions;
using AssetManagementAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AssetManagementAPI.Services
{
  
    public class CityService : ICityService
    {

        private readonly IRepository<City> _cityRepository;

        public CityService(IRepository<City> cityRepository)
        {
            this._cityRepository = cityRepository;
        }

        public List<City> GetCities()
        {
            return _cityRepository.GetAll().ToList();   
        }


        public int CreateCity(CityDTO city)
        {
            if(city.cityAbbr == null) {
                throw new ArgumentNullException("City Abbreviation cannot be null");
            }
            if (city.cityName == null)
            {
                throw new ArgumentNullException("City Name cannot be null");
            }
            var validator = new AbbrValidator<City>(GetCities());
            validator.ValidateAbbr(city.cityAbbr, City => City.CityAbbr);

            var cityNew = new City
            {
                CityName = city.cityName,
                CityAbbr = city.cityAbbr.ToUpper()
            };
            _cityRepository.Add(cityNew);
            _cityRepository.Save();
            return cityNew.CityId;
        }
     }
}
