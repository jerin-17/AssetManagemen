using AssetManagementAPI.Model;
using AssetManagementConsole.View;
using AssetManagementConsole.Managers;
using AssetManagementConsole.Interface;
using AssetManagementConsole.Api;
using AssetManagementAPI.DTO;

namespace AssetManagementConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            var cityManager = new CityManager(new CityInputFromConsole(), new EntityApi<City>(EndPointLookUp.GetEndPoint(EndPoint.City)));
            var buildingManager = new BuildingManager(new BuildingInputFromConsole(), new EntityApi<Building>(EndPointLookUp.GetEndPoint(EndPoint.Building)));
            var facilityManager = new FacilityManager(new FacilityInputFromConsole(cityManager, buildingManager), new EntityApi<Facility>(EndPointLookUp.GetEndPoint(EndPoint.Facility)));

            var seatManager = new SeatManager(new SeatInputFromConsole(facilityManager), new EntityApi<Seat>(EndPointLookUp.GetEndPoint(EndPoint.Seat)));
            var departmentManager = new DepartmentManager(new DepartmentFromConsole(),
                new EntityApi<Department>(EndPointLookUp.GetEndPoint(EndPoint.Department)));
            var employeeManager = new EmployeeManager(
                new EmployeeFromConsole(departmentManager),
                new EntityApi<EmployeeDTO>(EndPointLookUp.GetEndPoint(EndPoint.EmployeeBatch)),
                new EntityApi<Employee>(EndPointLookUp.GetEndPoint(EndPoint.Employee)));
            var allocatedReportProvider = new ReportApi<VAllocatedSeat>();
            var unallocatedReportProvider = new ReportApi<VUnAllocatedSeat>();
            var allocateReportManager = new ReportManager<VAllocatedSeat>(allocatedReportProvider);
            var unallocateReportManager = new ReportManager<VUnAllocatedSeat>(unallocatedReportProvider);
            var allocationProvider = new SeatAllocationApi();
            var allocationManager = new AllocationManager(new AllocateInputFromConsole(employeeManager, unallocateReportManager),
                new DeAllocateInputFromConsole(allocateReportManager), allocationProvider);
            var cabinManager = new CabinManager(new CabinInputFromConsole(facilityManager), new EntityApi<Cabin>(EndPointLookUp.GetEndPoint(EndPoint.Cabin)));
            var meetingRoomManager = new MeetingRoomManager(new MeetingRoomInputFromConsole(facilityManager), new EntityApi<MeetingRoom>(EndPointLookUp.GetEndPoint(EndPoint.MeetingRoom)));
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.Onboard Facility");
                Console.WriteLine("2.Onboard Seat");
                Console.WriteLine("3.Onboard Cabin");
                Console.WriteLine("4.Onboard MeetingRoom");
                Console.WriteLine("5.Upload EmployeeList");
                Console.WriteLine("6.Allocate Seat");
                Console.WriteLine("7.Deallocate Seat");
                Console.WriteLine("8.Generate Reports");

                Console.Write("Enter option:");
                Int32.TryParse(Console.ReadLine(), out int option);

                switch (option)
                {
                    case 1:
                        facilityManager.OnboardFacility();
                        break;
                    case 2:
                        seatManager.OnboardSeat();
                        break;
                    case 3: cabinManager.OnboardCabin(); break;
                    case 4: meetingRoomManager.OnboardMeetingRoom(); break;
                    case 5: employeeManager.CreateEmployee(); break;
                    case 6: allocationManager.Allocate(); break;
                    case 7: allocationManager.DeAllocate(); break;
                    case 8: new GenerateReportPage(allocateReportManager, unallocateReportManager).Display(); break;
                }
                Console.ReadKey();

            }
        }
    }
}