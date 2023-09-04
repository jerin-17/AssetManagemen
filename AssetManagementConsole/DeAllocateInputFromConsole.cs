using AssetManagementAPI.DTO;
using AssetManagementAPI.Model;
using AssetManagementConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole
{
    public class DeAllocateInputFromConsole : IInputProvider<DeallocateDTO>
    {

        private readonly IReportManager<VAllocatedSeat> _reportManager;

        public DeAllocateInputFromConsole( IReportManager<VAllocatedSeat> reportManager)
        {

            this._reportManager = reportManager;
        }

        

        private void iterateSeatsallocated(List<VAllocatedSeat> seats)
        {
            foreach (var seat in seats)
            {
                Console.WriteLine($"{seat.CityAbbr}-{seat.BuildingAbbr}-{seat.FloorNumber}-{seat.FacilityAbbr}-{seat.SeatNumber}");
            }
        }
        public DeallocateDTO GetInput()
        {
           
;
            iterateSeatsallocated(_reportManager.GenerateReport());
            Console.Write("Select seat id:");
            int.TryParse(Console.ReadLine(), out int seatId);
            return new DeallocateDTO {EntityId = seatId };

        }
    }
}
