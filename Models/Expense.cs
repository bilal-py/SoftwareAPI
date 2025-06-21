using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareAPI.Models
{
    public class Expense
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Amount { get; set; }
        public Guid CategoryId { get; set; } // Foreign Key
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;

        public string? Notes { get; set; }
    }
}
