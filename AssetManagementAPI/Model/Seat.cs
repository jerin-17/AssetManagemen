using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementAPI.Model
{
    public class Seat
    {
        [Key]
        public int SeatId { get; set; }
        public string SeatNumber { get; set; }
        [ForeignKey("FacilityId")]
        [Required]
        public int FacilityId { get; set; }

        [ForeignKey("EmployeeId")]
        public int? EmployeeId { get; set; }

        public virtual Facility Facility { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
