using AssetManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ReportController : Controller 
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            this._reportService = reportService;
        }
        [HttpGet]
        [Route("Allocated")]
        public IActionResult GetAllocatedReport()
        {
            return Ok(_reportService.GenerateAllocatedSeatReport());
        }
        [HttpGet]
        [Route("UnAllocated")]
        public IActionResult GetUnAllocatedReport()
        {
            return Ok(_reportService.GenerateUnAllocatedSeatReport());
        }
    }
}
