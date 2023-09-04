using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementAPI.Model
{
    public class Cabin
    {
        [Key]
        public int CabinId { get; set; }
        public string CabinNumber { get; set; }

        [ForeignKey("FacilityId")]
        public int FacilityId { get; set; }

        [ForeignKey("EmplyeeId")]
        public int? EmployeeId { get; set; }

        public virtual Facility Facility { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
