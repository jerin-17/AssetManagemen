using AssetManagementAPI.DTO;
using AssetManagementAPI.Interfaces;
using AssetManagementAPI.Model;

namespace AssetManagementAPI.Services
{
    public class MeetingRoomAssetService : IMeetingRoomAssetService
    {
        private readonly IRepository<MeetingRoomAsset> _meetingRoomAsset;

        public MeetingRoomAssetService(IRepository<MeetingRoomAsset> meetingRoomAsset)
        {
            this._meetingRoomAsset = meetingRoomAsset;
        }
        public List<MeetingRoomAsset> GetMeetingRoomAssets()
        {
            return _meetingRoomAsset.GetAll().ToList();
        }


        List<MeetingRoomAsset> IMeetingRoomAssetService.GetMeetingRoomAssets()
        {
            throw new NotImplementedException();
        }

       public void Create(MeetingRoomAssetDTO meetingRoomAsset)
        {
            if(meetingRoomAsset.AssetId == null) {
                throw new ArgumentNullException("AssetId cannot be null");
            }
            if (meetingRoomAsset.MeetingRoomId == null)
            {
                throw new ArgumentNullException("MeetingRoomId cannot be null");
            }

            _meetingRoomAsset.Add(new MeetingRoomAsset()
            {
                MeetingRoomId = meetingRoomAsset.MeetingRoomId,
                AssetId = meetingRoomAsset.AssetId
            });
        }
    }
}
