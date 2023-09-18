using AssetManagementAPI.Model;
using AssetManagementConsole.Interface;
using AssetManagementConsole.Managers;
using AssetManagementConsole.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole
{
    public class CityInputFromConsole : IInputProvider<City>
    { 

        public City GetInput()
        {
          
            Console.Write("Enter City Name");
            string cityName = Console.ReadLine();
            if(cityName == null)
            {
                throw new ArgumentNullException("city name cannot be null");
            }
            Console.Write("Enter City Abrreviation");
            string cityAbbr = Console.ReadLine();
            if (cityAbbr == null)
            {
                throw new ArgumentNullException("city Abrreviation cannot be null");
            }
            return new City
            {
                CityName = cityName,
                CityAbbr = cityAbbr
            };
        }
           
    }
}
