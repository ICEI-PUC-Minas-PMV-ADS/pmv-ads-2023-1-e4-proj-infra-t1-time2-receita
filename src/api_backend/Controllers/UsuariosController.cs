using backend_freecipes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend_freecipes.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        { 
            var model = await _context.Usuarios.ToListAsync();

            return Ok(model);
        }
        [HttpPost]
        public async Task<ActionResult>Create(UsuarioDto model)
        {
            Usuario novo = new Usuario()
            {
                Nome = model.Nome,
                Senha = BCrypt.Net.BCrypt.HashPassword(model.Senha),
                Email = model.Email,
                DataCadastro = model.DataCadastro,
            };

            _context.Usuarios.Add(novo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new {id = novo.Id}, novo);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Usuarios
                    .Include(t => t.Receitas)
                   .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();

            GerarLinks(model);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UsuarioDto model)
        {
            if(id != model.Id) return BadRequest();

            var modeloDb = await _context.Usuarios.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if(modeloDb == null) return NotFound();

            modeloDb.Nome = model.Nome;
            modeloDb.Senha = BCrypt.Net.BCrypt.HashPassword(model.Senha);
            modeloDb.Email = model.Email;
            modeloDb.DataCadastro = model.DataCadastro;

            _context.Usuarios.Update(modeloDb);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Usuarios.FindAsync(id);

            if (model == null) return NotFound(id);

            _context.Usuarios.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private void GerarLinks(Usuario model)
        {
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel:"self", metodo: "GET"));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "update", metodo: "PUT"));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "delete", metodo: "Delete"));
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult Authenticate(AuthenticateDto model)
        { 
            var usuarioDb = _context.Usuarios
                .Single(usuario => usuario.Email == model.Email);

            if (usuarioDb == null || !BCrypt.Net.BCrypt.Verify(model.Senha, usuarioDb.Senha))
                return Unauthorized();

            var jwt = GenerateJwtToken(usuarioDb);

            return Ok(new { jwtToken = jwt });
        }

        private string GenerateJwtToken(Usuario model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Ry74cBQva5dThwbwchR9jhbtRFnJxWSZ");
            var claims = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        
    }
}
