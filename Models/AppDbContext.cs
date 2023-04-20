using Microsoft.EntityFrameworkCore;

namespace backend_freecipes.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Etapa> Etapas { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
