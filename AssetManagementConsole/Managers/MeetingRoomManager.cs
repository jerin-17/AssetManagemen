using AssetManagementAPI.Model;
using AssetManagementConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Managers
{
    public class MeetingRoomManager
    {
        private readonly IInputProvider<MeetingRoom> _meetingRoomInput;
        private readonly IEntityManager<MeetingRoom> _entityManager;

        public MeetingRoomManager(IInputProvider<MeetingRoom> meetingRoomInput, IEntityManager<MeetingRoom> entityManager)
        {
            this._meetingRoomInput = meetingRoomInput;
            this._entityManager = entityManager;
        }

        public int OnboardMeetingRoom()
        {
            MeetingRoom meetingRoom = _meetingRoomInput.GetInput();
            _entityManager.Create(meetingRoom);
            return meetingRoom.FacilityId;

        }

        public List<MeetingRoom> GetMeetingRooms()
        {
            return _entityManager.GetAll();
        }
    }
}
