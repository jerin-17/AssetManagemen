using AssetManagementAPI.DTO;
using AssetManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomController : Controller
    {
        private readonly IMeetingRoomService _meetingRoomService;

        public MeetingRoomController(IMeetingRoomService meetingRoomService)
        {
            this._meetingRoomService = meetingRoomService;
        }
        [HttpGet]
        public IActionResult GetDetails()
        {

            return Ok(_meetingRoomService.GetMeetingRooms());
        }

        [HttpPost]
        public IActionResult Create(MeetingRoomDTO meetingRoom)
        {

            try
            {
                _meetingRoomService.CreateMeetingRoom(meetingRoom);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
