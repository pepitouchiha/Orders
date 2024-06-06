using Microsoft.EntityFrameworkCore;
using Orders.Shared.Entities;

namespace Orders.Backend.Data
{
	public class DataContext : DbContext //Buscar en instalar la ultima version de entity framework para el dbcontext
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; } //Importa del archivo shared el modelo de country, pluraliza los countries en ingles bien

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
		}
	}
}
