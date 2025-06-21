namespace SoftwareAPI.DTO
{
    public class ExpenseDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public string? Notes { get; set; }
    }
}
