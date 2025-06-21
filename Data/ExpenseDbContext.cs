using Microsoft.EntityFrameworkCore;
using SoftwareAPI.Models;

namespace SoftwareAPI.Data
{
    public class ExpenseDbContext: DbContext
    {
        public ExpenseDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
