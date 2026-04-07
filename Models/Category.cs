using System.ComponentModel.DataAnnotations;

namespace Labb1_LINQ.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<Product> Products { get; set; } = [];
    }
}
