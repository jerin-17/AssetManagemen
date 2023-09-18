using AssetManagementAPI.Model;
using AssetManagementConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole
{
    public class CabinInputFromConsole : IInputProvider<Cabin>
    {
        private readonly IFacilityManager _facilityManager;

        public CabinInputFromConsole(IFacilityManager facilityManager)
        {
            this._facilityManager = facilityManager;
        }

        private void iterateFacilities(List<Facility> facilities)
        {
            foreach (var facility in facilities)
            {
                Console.WriteLine($"{facility.FacilityId} {facility.FacilityName}");
            }
        }

        public Cabin GetInput()
        {
            Console.WriteLine("1.Select from facility");
            Console.WriteLine("2. Create new facility");
            Console.Write("Select an option: ");
            Int32.TryParse(Console.ReadLine(), out int facilityOption);
            int facilityId = 0;

            switch (facilityOption)
            {
                case 1:
                    iterateFacilities(_facilityManager.GetFacilities());
                    Console.Write("Option: ");
                    Int32.TryParse(Console.ReadLine(), out facilityId);
                    break;
                case 2:
                    facilityId = _facilityManager.OnboardFacility();
                    break;
            }

            Console.Write("Enter Cabin number:");
            string seatNumber = Console.ReadLine();
            if (seatNumber == null)
            {
                throw new ArgumentNullException("Seat number cannot be null");
            }

            return new Cabin
            {
                FacilityId = facilityId,
                CabinNumber = seatNumber
            };

        }
    }
}
