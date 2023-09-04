using AssetManagementAPI.DTO;
using AssetManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;
using AssetManagementAPI.Interfaces;

namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            this._buildingService = buildingService;
        }
        [HttpGet]
        public IActionResult GetDetails()
        {

            return Ok(_buildingService.GetBuildings());
        }

        [HttpPost]
        public IActionResult Create(BuildingDTO building)
        {

            try
            {
              int id =  _buildingService.CreateBuilding(building);
                return Ok(id);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
