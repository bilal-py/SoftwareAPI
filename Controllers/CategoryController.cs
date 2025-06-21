using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareAPI.Data;
using SoftwareAPI.DTO;
using SoftwareAPI.Models;

namespace SoftwareAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ExpenseDbContext _context;

        public CategoryController(ExpenseDbContext context)
        {
            _context = context;
        }

        // GET: api/category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _context.Category.ToListAsync();
            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }

        // GET: api/category/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CategoryDto>> GetCategory([FromRoute] Guid id)
        {
            var category = await _context.Category.FindAsync(id);

            if (category == null)
                return NotFound();

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        // POST: api/category
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CategoryDto dto)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = dto.Name
            };

            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            dto.Id = category.Id;
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, dto);
        }

        // PUT: api/category/5
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, CategoryDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var category = await _context.Category.FindAsync(id);
            if (category == null)
                return NotFound();

            category.Name = dto.Name;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/category/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
                return NotFound();

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
