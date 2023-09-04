using AssetManagementAPI.DTO;
using AssetManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomAssetController : Controller
    {
        private readonly IMeetingRoomAssetService _meetingRoomAssetService;

        public MeetingRoomAssetController(IMeetingRoomAssetService meetingRoomAssetService)
        {
            this._meetingRoomAssetService = meetingRoomAssetService;
        }
        [HttpGet]
        public IActionResult GetDetails()
        {
            return Ok(_meetingRoomAssetService.GetMeetingRoomAssets());
        }

        [HttpPost]
        public IActionResult Create(MeetingRoomAssetDTO meetingRoomAsset)
        {
            try
            {
                _meetingRoomAssetService.Create(meetingRoomAsset);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }


}
