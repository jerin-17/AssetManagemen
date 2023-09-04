using System.ComponentModel.DataAnnotations;

namespace AssetManagementAPI.Model
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }
        public string AssetName { get; set; }
    }
}
