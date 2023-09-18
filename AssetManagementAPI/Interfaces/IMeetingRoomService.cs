using AssetManagementAPI.DTO;
using AssetManagementAPI.Model;

namespace AssetManagementAPI.Interfaces
{
    public interface IMeetingRoomService
    {
        List<MeetingRoom> GetMeetingRooms();
        int CreateMeetingRoom(MeetingRoomDTO  meetingRoom);
    }
}
