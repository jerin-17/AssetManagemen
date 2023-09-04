using System.ComponentModel.DataAnnotations;

namespace AssetManagementAPI.Model
{
    public class Building
    {
        [Key]
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public string BuildingAbbr { get; set; }

    }
}
