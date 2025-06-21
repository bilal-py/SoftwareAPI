using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SoftwareAPI.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        [JsonIgnore]
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
