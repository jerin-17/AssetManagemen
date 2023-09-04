using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementAPI.Model
{
    public class MeetingRoomAsset
    {
        [Key]
        public int MeetingRoomSeatId { get; set; }
        [ForeignKey("MeetingRoomId")]
        [Required]
        public int MeetingRoomId { get; set; }
        [ForeignKey("AssetId")]
        [Required]
        public int AssetId { get; set; }
        public int Quantity { get; set; }

        public virtual MeetingRoom Meeting { get; set; }
        public virtual Asset Asset { get; set; }
    }
}
