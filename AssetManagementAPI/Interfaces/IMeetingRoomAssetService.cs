using AssetManagementAPI.DTO;
using AssetManagementAPI.Model;

namespace AssetManagementAPI.Interfaces
{
    public interface IMeetingRoomAssetService
    {
        List<MeetingRoomAsset> GetMeetingRoomAssets();
        void Create(MeetingRoomAssetDTO meetingRoomAsset);
    }
}
