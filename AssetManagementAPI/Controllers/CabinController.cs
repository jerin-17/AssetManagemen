using AssetManagementAPI.DTO;
using AssetManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinController : Controller
    {
        private readonly ICabinService _cabinService;

        public CabinController(ICabinService cabinService)
        {
            this._cabinService = cabinService;
        }

        [HttpGet]
        public IActionResult GetDetails()
        {
            return Ok(_cabinService.GetCabins());
        }

        [HttpPost]
        public IActionResult Create(CabinDTO cabin)
        {
            try
            {
             _cabinService.CreateCabin(cabin);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("Allocate")]
        [HttpPatch]
        public IActionResult Allocate(AllocateDTO allocate)
        {
            try
            {
                _cabinService.AllocateCabin(allocate.EntityId,allocate.EmployeeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Deallocate")]
        [HttpPatch]
        public IActionResult Deallocate(DeallocateDTO deallocate)
        {
            try
            {
                _cabinService.DeallocateCabin(deallocate.EntityId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
