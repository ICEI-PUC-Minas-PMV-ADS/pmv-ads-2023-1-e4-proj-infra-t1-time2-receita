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

            builder.Entity<ReceitaEtapas>().HasKey(c => new { c.ReceitaId, c.EtapaId });

            builder.Entity<ReceitaEtapas>().HasOne(c => c.Receita)
                .WithMany(c => c.Etapas).HasForeignKey(c => c.ReceitaId);

            builder.Entity<ReceitaEtapas>().HasOne(c => c.Etapa)
                .WithMany(c => c.Receitas).HasForeignKey(c => c.EtapaId);

            builder.Entity<ReceitaIngredientes>().HasKey(c => new { c.ReceitaId, c.IngredienteId });

            builder.Entity<ReceitaIngredientes>().HasOne(c => c.Receita)
                .WithMany(c => c.Ingredientes).HasForeignKey(c => c.ReceitaId);

            builder.Entity<ReceitaIngredientes>().HasOne(c => c.Ingrediente)
                .WithMany(c => c.Receitas).HasForeignKey(c => c.IngredienteId);
        }

        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Etapa> Etapas { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ReceitaEtapas> ReceitasEtapas { get; set; }
        public DbSet<ReceitaIngredientes> ReceitasIngredientes { get; set; }
    }
}
