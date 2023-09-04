using AssetManagementAPI.Interfaces;
using AssetManagementAPI.Model;

namespace AssetManagementAPI.Services
{
    public class ReportService : IReportService
    {
        private readonly IRepository<VAllocatedSeat> _allocatedReportRepository;
        private readonly IRepository<VUnAllocatedSeat> _unallocatedReportRepository;

        public ReportService(IRepository<VAllocatedSeat> AllocateRepository, IRepository<VUnAllocatedSeat> UnAllocateRepository)
        {
            this._allocatedReportRepository = AllocateRepository;
            this._unallocatedReportRepository = UnAllocateRepository;
        }

        public List<VAllocatedSeat> GenerateAllocatedSeatReport()
        {
            return _allocatedReportRepository.GetAll().ToList();
        }

        public List<VUnAllocatedSeat> GenerateUnAllocatedSeatReport()
        {
            return _unallocatedReportRepository.GetAll().ToList();
        }

    }
}
