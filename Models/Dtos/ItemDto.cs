using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Models.Dtos
{
    public class ItemDto
    {
        [Required]
        [StringLength(30, ErrorMessage = "Name has to be maximum of 50 character")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(30, ErrorMessage = "Brand Name has to be maximum of 50 character")]
        public string BrandName { get; set; } = string.Empty;
        [Required]
        [StringLength(30, ErrorMessage = "Color has to be maximum of 50 character")]
        public string Color { get; set; } = string.Empty;
        [Required]
        [StringLength(30, ErrorMessage = "Ram has to be maximum of 50 character")]
        public string Ram { get; set; } = string.Empty;
        [Required]
        [StringLength(30, ErrorMessage = "Rom has to be maximum of 50 character")]
        public string Rom { get; set; } = string.Empty;
        [Required]
        public int CameraMP { get; set; }
        [Required]
        public string Image { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
