using AssetManagementAPI.Model;
using AssetManagementConsole.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.View
{
    public class BuildingInputFromConsole : IInputProvider<Building>
    {
        public Building GetInput()
        {

            Console.Write("Enter Building Name");
            string buildingName = Console.ReadLine();
            if (buildingName == null)
            {
                throw new ArgumentNullException("Building name cannot be null");
            }
            Console.Write("Enter Building Abrreviation");
            string buildingAbbr = Console.ReadLine();
            if (buildingAbbr == null)
            {
                throw new ArgumentNullException("Building Abrreviation cannot be null");
            }
            return new Building
            {
                BuildingName = buildingName,
                BuildingAbbr = buildingAbbr
            };
        }
    }
}
