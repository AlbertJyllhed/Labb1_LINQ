using System.ComponentModel.DataAnnotations;

namespace Labb1_LINQ.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }

        [Range(0, 999, ErrorMessage = "Total amount must be non-negative.")]
        public int TotalAmount { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Behandlas";

        // Navigation properties
        public Customer Customer { get; set; } = null!;
        public ICollection<OrderDetail> OrderDetails { get; set; } = [];
    }
}
