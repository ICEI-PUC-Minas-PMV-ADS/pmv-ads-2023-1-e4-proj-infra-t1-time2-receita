using Microsoft.EntityFrameworkCore;

namespace backend_freecipes.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Receita>()
                .HasOne(c => c.Usuario).WithMany(c => c.Receitas)
                .HasForeignKey(c => c.UsuarioId);

           
        }

        public DbSet<Receita> Receitas { get; set; }
        
        public DbSet<Usuario> Usuarios { get; set; }
       
    }
}
