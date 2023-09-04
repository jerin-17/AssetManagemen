using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementAPI.Model
{
    public class MeetingRoom
    {
        [Key]
        public int MeetingRoomId { get; set; }
        public string MeetingRoomNumber { get; set; }
        public int SeatCount { get; set; }
        [ForeignKey("FacilityId")]
        public int FacilityId { get; set; }

        public virtual Facility Facility { get; set; }
    }
}
