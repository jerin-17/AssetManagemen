using System.ComponentModel.DataAnnotations;

namespace AssetManagementAPI.Model
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityAbbr { get; set; }
    }
}
