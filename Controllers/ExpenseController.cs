
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using SoftwareAPI.Data;
using SoftwareAPI.DTO;
using SoftwareAPI.Models;
using Microsoft.AspNetCore.Authorization;


namespace ExpenseTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly ExpenseDbContext _context;

        public ExpensesController(ExpenseDbContext context)
        {
            _context = context;
        }

        // GET: api/expenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseResponseDto>>> GetAllExpenses()
        {
            var expenses = await _context.Expenses.Include(e => e.Category).ToListAsync();

            return expenses.Select(e => new ExpenseResponseDto
            {
                Id = e.Id,
                Name = e.Name,
                Amount = e.Amount,
                CategoryName = e.Category?.Name ?? "No Category",
                CreatedDate = e.CreatedDate,
                Notes = e.Notes
            }).ToList();
        }



        // GET: api/expenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseResponseDto>> GetExpenseById(Guid id)
        {
            var expense = await _context.Expenses.Include(e => e.Category).FirstOrDefaultAsync(e => e.Id == id);
            if (expense == null) return NotFound();

            return new ExpenseResponseDto
            {
                Id = expense.Id,
                Name = expense.Name,
                Amount = expense.Amount,
                CategoryName = expense.Category?.Name ?? "No Category",
                CreatedDate = expense.CreatedDate,
                Notes = expense.Notes
            };
        }



        // POST: api/expenses
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ExpenseResponseDto>> CreateExpense(ExpenseDto dto)
        {
            var category = await _context.Category.FindAsync(dto.CategoryId);
            if (category == null)
            {
                return BadRequest("Invalid CategoryId");
            }

            var expense = new Expense
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Amount = dto.Amount,
                CategoryId = dto.CategoryId,
                Category = category,
                Notes = dto.Notes,
                CreatedDate = dto.CreatedDate,
            };

            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();

            var responseDto = new ExpenseResponseDto
            {
                Id = expense.Id,
                Name = expense.Name,
                Amount = expense.Amount,
                Notes = expense.Notes,
                CategoryName = category.Name,
                CreatedDate = expense.CreatedDate
            };

            return CreatedAtAction(nameof(GetExpenseById), new { id = expense.Id }, responseDto);
        }




        // PUT: api/expenses/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ExpenseResponseDto>> UpdateExpense(Guid id, ExpenseDto dto)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null) return NotFound();

            var category = await _context.Category.FindAsync(dto.CategoryId);
            if (category == null) return BadRequest("Invalid CategoryId");

            expense.Name = dto.Name;
            expense.Amount = dto.Amount;
            expense.Notes = dto.Notes;
            expense.CategoryId = dto.CategoryId;
            expense.CreatedDate = dto.CreatedDate ?? expense.CreatedDate;

            await _context.SaveChangesAsync();

            return new ExpenseResponseDto
            {
                Id = expense.Id,
                Name = expense.Name,
                Amount = expense.Amount,
                Notes = expense.Notes,
                CreatedDate = expense.CreatedDate,
                CategoryName = category.Name
            };
        }




        // DELETE: api/expenses/5
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteExpense([FromRoute] Guid id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
                return NotFound();

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PATCH: api/expenses/5
        [HttpPatch]
        [Route("{id:guid}")]
        public async Task<IActionResult> PatchExpense([FromRoute] Guid id, [FromBody] JsonPatchDocument<Expense> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
                return NotFound();

            patchDoc.ApplyTo(expense, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}