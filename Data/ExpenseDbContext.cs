using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftwareAPI.Models;

namespace SoftwareAPI.Data
{
    public class ExpenseDbContext : IdentityDbContext<IdentityUser>
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options): base(options) { }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
