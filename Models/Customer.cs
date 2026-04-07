using System.ComponentModel.DataAnnotations;

namespace Labb1_LINQ.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        [MaxLength(100)]
        public string? Email { get; set; } = string.Empty;

        [Phone]
        [MaxLength(40)]
        public string? Phone { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<Order> Orders { get; set; } = [];
    }
}
