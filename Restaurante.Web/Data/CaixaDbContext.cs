using Microsoft.EntityFrameworkCore;

namespace Restaurante.Web.Data
{
    public class RestauranteDbContext: DbContext
    {
        public RestauranteDbContext(DbContextOptions<RestauranteDbContext> options) : base(options) { }

        public DbSet<Ingrediente> Ingredientes => Set<Ingrediente>();
        public DbSet<Prato> Pratos => Set<Prato>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingrediente>().HasIndex(turma => turma.Nome).IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
