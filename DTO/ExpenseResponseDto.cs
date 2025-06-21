namespace SoftwareAPI.DTO
{
    public class ExpenseResponseDto
    {
        //Used to return Expense info with CategoryName
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string? Notes { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public DateTime? CreatedDate { get; set; }
    }
}
