using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole
{
    public enum EndPoint
    {
        Report,
        Facility,
        City,
        Building,
        Seat,
        Employee,
        EmployeeBatch,
        Department,
        AllocateReport,
        DeAllocateReport,
        Cabin,
        MeetingRoom

    }

    public class EndPointLookUp
    {
        public static string GetEndPoint(EndPoint endPoint)
        {
            var endPointDictionary = new Dictionary<EndPoint, string>()
            {
                { EndPoint.Report , "api/report" },
                {EndPoint.Facility, "api/Facility" },
                { EndPoint.City, "api/City" },
                {EndPoint.Building,"api/Building" },
                {EndPoint.Seat, "api/Seat" },
                {EndPoint.Employee, "api/Employee" },
                { EndPoint.EmployeeBatch, "api/Employee/CreateBatch" },
                { EndPoint.Department,"api/Department"},
                { EndPoint.AllocateReport,"api/Report/Allocated"},
                { EndPoint.DeAllocateReport,"api/Report/UnAllocated"},
                 { EndPoint.Cabin,"api/Cabin"},
                {EndPoint.MeetingRoom,"api/MeetingRoom" }
            };

            return endPointDictionary[endPoint];
        }
    }
}
