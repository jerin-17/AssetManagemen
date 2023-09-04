using AssetManagementAPI.Model;

namespace AssetManagementAPI.Interfaces
{
    public interface IReportService
    {
        List<VAllocatedSeat> GenerateAllocatedSeatReport();
        List<VUnAllocatedSeat> GenerateUnAllocatedSeatReport();

    }
}
