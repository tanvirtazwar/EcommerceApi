using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Models.Domains
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(30)]
        public string BrandName { get; set; } = string.Empty;
        [Required]
        [StringLength(30)]
        public string Color { get; set; } = string.Empty;
        [Required]
        [StringLength(30)]
        public string Ram { get; set; } = string.Empty;
        [Required]
        [StringLength(30)]
        public string Rom { get; set; } = string.Empty;
        [Required]
        public int CameraMP { get; set; }
        public string[] Images { get; set; } = new string[3];
    }
}
