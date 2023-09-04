using AssetManagementAPI.Model;
using AssetManagementConsole.Api;
using AssetManagementConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.View
{
    public class GenerateReportPage
    {
        private readonly IReportManager<VAllocatedSeat> _allocateReportManager;
        private IReportManager<VUnAllocatedSeat> _unallocateReportManager;

        public GenerateReportPage(IReportManager<VAllocatedSeat> allocateReportManager, IReportManager<VUnAllocatedSeat> unallocateReportManager) {
            this._allocateReportManager = allocateReportManager;
            this._unallocateReportManager = unallocateReportManager;
        }

        public  void iterateAllocated(List<VAllocatedSeat> seats)
        {
            foreach(var seat in seats) {
                Console.WriteLine($"{seat.SeatId} {seat.CityAbbr} {seat.BuildingAbbr} {seat.FloorNumber} {seat.FacilityAbbr}" +
                    $"{seat.SeatNumber} {seat.EmployeeName}");
            }
        }

        public void iterateUnAllocated(List<VUnAllocatedSeat> seats)
        {
            foreach (var seat in seats)
            {
                Console.WriteLine($"{seat.SeatId} {seat.CityAbbr} {seat.BuildingAbbr} {seat.FloorNumber} {seat.FacilityAbbr}" +
                    $"{seat.SeatNumber}");
            }
        }


        public void AllocateReportDisplay()
        {
            Console.WriteLine("1. Generate Report");
            Console.WriteLine("2. Filter By City");
            Console.WriteLine("3. Filter By Building");
            Console.WriteLine("4. Filter By Facility");

            Console.Write("Enter Option: ");
            int.TryParse(Console.ReadLine(), out int option);

            switch (option)
            {
                case 1: iterateAllocated(_allocateReportManager.GenerateReport());
                    break;
                case 2:
                    Console.Write("Enter the city Abbreviation:");
                    string abbrCity = Console.ReadLine();
                    iterateAllocated(_allocateReportManager.Filter(_allocateReportManager.GenerateReport(), abbrCity, seat => seat.CityAbbr));
                    break;
                case 3:
                    Console.Write("Enter the Facility Abbreviation:");
                    string abbrBuilding = Console.ReadLine();
                    iterateAllocated(_allocateReportManager.Filter(_allocateReportManager.GenerateReport(), abbrBuilding, seat => seat.BuildingAbbr));
                    break;
                case 4:
                    Console.Write("Enter the Facility Abbreviation:");
                    string abbrFacility = Console.ReadLine();
                    iterateAllocated(_allocateReportManager.Filter(_allocateReportManager.GenerateReport(), abbrFacility, seat => seat.FacilityAbbr));
                    break;
            }
        }

        public void UnAllocateReportDisplay()
        {
            Console.WriteLine("1. Generate Report");
            Console.WriteLine("2. Filter By City");
            Console.WriteLine("3. Filter By Building");
            Console.WriteLine("4. Filter By Facility");

            Console.Write("Enter Option: ");
            int.TryParse(Console.ReadLine(), out int option);

            switch (option)
            {
                case 1:
                    iterateUnAllocated(_unallocateReportManager.GenerateReport());
                    break;
                case 2:
                    Console.Write("Enter the city Abbreviation:");
                    string abbrCity = Console.ReadLine();
                    iterateUnAllocated(_unallocateReportManager.Filter(_unallocateReportManager.GenerateReport(), abbrCity, seat => seat.CityAbbr));
                    break;
                case 3:
                    Console.Write("Enter the Facility Abbreviation:");
                    string abbrBuilding = Console.ReadLine();
                    iterateUnAllocated(_unallocateReportManager.Filter(_unallocateReportManager.GenerateReport(), abbrBuilding, seat => seat.BuildingAbbr));
                    break;
                case 4:
                    Console.Write("Enter the Facility Abbreviation:");
                    string abbrFacility = Console.ReadLine();
                    iterateUnAllocated(_unallocateReportManager.Filter(_unallocateReportManager.GenerateReport(), abbrFacility, seat => seat.BuildingAbbr));
                    break;
            }
        }

        public  void Display()
        {
            Console.WriteLine("1. Allocated Seats Report");
            Console.WriteLine("2. Deallocated Seats Report");

            Console.Write("Enter option: ");
            Int32.TryParse(Console.ReadLine(), out int option);

            switch(option)
            {
                case 1:
                    AllocateReportDisplay();
                    break;
                case 2:
                    UnAllocateReportDisplay();
                    break;
            }
        }
    }
}
