using AssetManagementAPI.DTO;
using AssetManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class FacilityController : Controller
    {
        private readonly IFacilityService _facilityService;
      
        public FacilityController(IFacilityService facilityService)
        {
            this._facilityService = facilityService;
        }
        [HttpGet]
        public IActionResult GetDetails()
        {
            return Ok(_facilityService.GetFacilities());
        }
        [HttpPost]
        public IActionResult Create(FacilityDTO facility) {
            try
            {
                int id = _facilityService.CreateFacility(facility);
                return Ok(id);
            }catch (Exception ex) { 
                 return BadRequest(ex.Message);
                }
            
        }
    }
}
