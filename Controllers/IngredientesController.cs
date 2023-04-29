using backend_freecipes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_freecipes.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IngredientesController(AppDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Ingredientes.ToListAsync();
            return Ok(model);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Ingrediente model)
        {

            _context.Ingredientes.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Ingredientes
                .Include(t => t.Receitas)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();

            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Ingrediente model)
        {
            if (id != model.Id) return BadRequest();

            var modeloDb = await _context.Ingredientes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            if (modeloDb == null) return NotFound();
            _context.Ingredientes.Update(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Ingredientes.FindAsync(id);

            if (model == null) return NotFound();

            _context.Ingredientes.Remove(model);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
