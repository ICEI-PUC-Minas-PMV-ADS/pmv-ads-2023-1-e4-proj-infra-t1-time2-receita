using backend_freecipes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_freecipes.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReceitasController(AppDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Receitas.ToListAsync();
            return Ok(model);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Receita model)
        {
           
            _context.Receitas.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Receitas
                .Include(t => t.Usuario)
                .Include(t => t.Etapas).ThenInclude(t => t.Etapa)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();

            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Receita model)
        {
            if (id != model.Id) return BadRequest();

            var modeloDb = await _context.Receitas.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            if (modeloDb == null) return NotFound();

            _context.Receitas.Update(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Receitas.FindAsync(id);

            if (model == null) return NotFound();

            _context.Receitas.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("{id}/etapas")]
        public async Task<ActionResult> AddEtapa(int id, ReceitaEtapas model)
        {
            if (id != model.ReceitaId) return BadRequest();
            _context.ReceitasEtapas.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.ReceitaId }, model);
        }
        [HttpDelete("{id}/etapas/{etapaId}")]
        public async Task<ActionResult> DeleteEtapa(int id, int etapaId)
        {
            var model = await _context.ReceitasEtapas
                .Where(c => c.ReceitaId == id && c.EtapaId == etapaId)
                .FirstOrDefaultAsync();

            if (model == null) return NotFound();

            _context.ReceitasEtapas.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
