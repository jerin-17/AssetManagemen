using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementAPI.Model
{
    public class Facility
    {
        [Key]
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public string FacilityAbbr { get; set; }
        public int FloorNumber { get; set; }

        [ForeignKey("BuildingId")]
        [Required]
        public int BuildingId { get; set; }
        [ForeignKey("CityId")]
        [Required]
        public int CityId { get; set; }

        public virtual Building Building { get; set; }
        public virtual City City { get; set; }

    }
}
