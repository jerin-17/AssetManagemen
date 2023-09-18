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
    public class AllocateInputFromConsole : IInputProvider<AllocateDTO>
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly IReportManager<VUnAllocatedSeat> _reportManager;

        public AllocateInputFromConsole(IEmployeeManager employeeManager,IReportManager<VUnAllocatedSeat> reportManager) {
            this._employeeManager = employeeManager;
            this._reportManager = reportManager;    
        }

        private void iterateEmployeesUnallocated(List<Employee> employees)
        {
            foreach (Employee employee in employees)
            {
                if (!employee.IsAllocated)
                {
                    Console.WriteLine($"{employee.EmployeeId}\t{employee.EmployeeName}");
                }
            }
        }

        private void iterateSeatsUnallocated(List<VUnAllocatedSeat> seats)
        {
            foreach (var seat in seats)
            {
                Console.WriteLine($"{seat.SeatId}. {seat.CityAbbr}-{seat.BuildingAbbr}-{seat.FloorNumber}-{seat.FacilityAbbr}-{seat.SeatNumber}");
            }
        }
        public AllocateDTO GetInput()
        {
            iterateEmployeesUnallocated(_employeeManager.GetEmployees());
            Console.Write("Select employee Id:");
            int.TryParse(Console.ReadLine(), out int employeeId);
            iterateSeatsUnallocated(_reportManager.GenerateReport());
            Console.Write("Select seat id:");
            int.TryParse(Console.ReadLine(), out int seatId);
            return new AllocateDTO { EmployeeId = employeeId,EntityId = seatId };

        }
    }
}
