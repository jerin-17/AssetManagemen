using AssetManagementAPI.Model;
using AssetManagementConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Managers
{
    public class CityManager : ICityManager

    {
        private readonly IEntityManager<City> _entityManager;
        private readonly IInputProvider<City> _cityInput;
        public CityManager(IInputProvider<City> cityInput,IEntityManager<City> entityManager) 
        {
            _entityManager = entityManager;
            _cityInput = cityInput;
        }
        public List<City> GetCities()
        {
            return _entityManager.GetAll();
        }

        public City GetCityById(int id)
        {
            return _entityManager.GetById(id);
        }
        public int OnboardCity()
        {
            var city = _cityInput.GetInput();
           int id = _entityManager.Create(city);
            return id;
        }

    }
}
