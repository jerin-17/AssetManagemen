using AssetManagementAPI.Model;
using AssetManagementConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole
{
    public class FacilityInputFromConsole : IInputProvider<Facility>
    {
        private readonly ICityManager _cityManager;
        private readonly IBuildingManager _buildingManager;
        public FacilityInputFromConsole(ICityManager cityManager, IBuildingManager buildingManager)
        {
            this._cityManager = cityManager;
            this._buildingManager = buildingManager;
        }

        private void iterateCities(List<City> cities)
        {
            foreach (City city in cities) {
                Console.WriteLine($"{city.CityId}\t{city.CityAbbr}\t{city.CityName}");
            }
                
        }

        private void iterateBuildings(List<Building> buildings)
        {
            foreach (var building in buildings)
            {
                Console.WriteLine($"{building.BuildingId}\t{building.BuildingAbbr}\t{building.BuildingName}");
            }

        }
        public Facility GetInput()
        {
            Console.WriteLine("1. Select from Cities");
            Console.WriteLine("2. Create a new City");
            Console.Write("Select option: ");
            int.TryParse(Console.ReadLine(), out int cityOption);
            int cityId = -1;
            if(cityOption == 1)
            {
                iterateCities(_cityManager.GetCities());
                Console.Write("Select CityId:");
                int.TryParse(Console.ReadLine(), out cityId);
            }else if(cityOption == 2)
            {
                try
                {
                    cityId = _cityManager.OnboardCity();

                }catch(ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }

            Console.WriteLine("1. Select from Buildings");
            Console.WriteLine("2. Create a new Building");
            Console.Write("Select option: ");
            int.TryParse(Console.ReadLine(), out int buildingOption);
            int buildingId = -1;
            if (buildingOption == 1)
            {
                iterateBuildings(_buildingManager.GetBuildings());
                Console.Write("Select BuildingId:");
                int.TryParse(Console.ReadLine(), out buildingId);
            }
            else if (buildingOption == 2)
            {
                try
                {
                    buildingId = _buildingManager.OnboardBuilding();

                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }

            Console.Write("Enter Floor Number: ");
            Int32.TryParse(Console.ReadLine(), out int floorNumber);
            Console.Write("Enter Facility Name:");
            string facilityName = Console.ReadLine();
           if(facilityName == null)
            {
                throw new ArgumentNullException("facility Name should not be null");
            }
            Console.Write("Enter Facility Abbreviation: ");
            string facilityAbbr = Console.ReadLine();
            if (facilityAbbr == null)
            {
                throw new ArgumentNullException("facility Abbreviation should not be null");
            }
            return new Facility()
            {
                CityId = cityId,
                BuildingId = buildingId,
                FloorNumber = floorNumber,
                FacilityName = facilityName,
                FacilityAbbr = facilityAbbr
            };
        }
    }
}
