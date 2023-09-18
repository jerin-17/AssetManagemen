using AssetManagementAPI.DTO;
using AssetManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : Controller
    {
        private readonly ISeatService _seatService;

        public SeatController(ISeatService seatService) { 
          this._seatService = seatService;
        }

        [HttpGet]
        public IActionResult GetDetails()
        {
            return Ok(_seatService.GetSeats());
        }

        [HttpPost]
        public IActionResult Create(SeatDTO seat)
        {
            try
            {
               int id = _seatService.CreateSeat(seat);
                return Ok(id);
            }
            catch(Exception ex)
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
                _seatService.AllocateSeat(allocate.EntityId, allocate.EmployeeId);
                return Ok();
            }catch(Exception ex)
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
                _seatService.DeallocateSeat(deallocate.EntityId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
