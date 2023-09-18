using AssetManagementAPI.DTO;
using AssetManagementAPI.Interfaces;
using AssetManagementAPI.Model;
using AssetManagementAPI.Utility;

namespace AssetManagementAPI.Services
{
    public class MeetingRoomService : IMeetingRoomService
    {
        private readonly IRepository<MeetingRoom> _meetingRoomRepository;

        public MeetingRoomService(IRepository<MeetingRoom> meetingRoomRepository)
        {
            this._meetingRoomRepository = meetingRoomRepository;
        }

        public List<MeetingRoom> GetMeetingRooms()
        {
            return _meetingRoomRepository.GetAll().ToList();
        }


        public int CreateMeetingRoom(MeetingRoomDTO meetingRoom)
        {
            if (meetingRoom.MeetingRoomNumber == null)
            {
                throw new ArgumentNullException("Meeting room number cannot be null");
            }
            if (meetingRoom.FacilityId == null)
            {
                throw new ArgumentNullException("Facility Id cannot be null");
            }
            var meetingRoomNew = new MeetingRoom
            {
                MeetingRoomNumber = meetingRoom.MeetingRoomNumber,
                SeatCount = meetingRoom.SeatCount,
                FacilityId = meetingRoom.FacilityId,
            };
            _meetingRoomRepository.Add(meetingRoomNew);
            _meetingRoomRepository.Save();
            return meetingRoomNew.MeetingRoomId;
        }
    }
}
