using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Freecipes_app.Models
{
    public class ApplicationDbContext : DbContext // classe criada
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
