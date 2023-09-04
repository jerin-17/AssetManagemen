using AssetManagementAPI.Model;
using AssetManagementConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole
{
    public class MeetingRoomInputFromConsole : IInputProvider<MeetingRoom>
    {
        private readonly IFacilityManager _facilityManager;

        public MeetingRoomInputFromConsole(IFacilityManager facilityManager)
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

        public MeetingRoom GetInput()
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

            Console.Write("Enter MeetingRoom number:");
            string seatNumber = Console.ReadLine();
            if (seatNumber == null)
            {
                throw new ArgumentNullException("Seat number cannot be null");
            }
            Console.Write("Enter the MeetingRoom Capacity: ");
            int.TryParse(Console.ReadLine(), out int meetingRoomCapacity);

            return new MeetingRoom
            {
                FacilityId = facilityId,
                MeetingRoomNumber = seatNumber,
                SeatCount = meetingRoomCapacity
            };

        }
    }
}
