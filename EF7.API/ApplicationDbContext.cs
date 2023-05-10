using EF7.API.Entidades;
using EF7.API.Entidades.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EF7.API
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Genero> Generos => Set<Genero>();
        public DbSet<Actor> Actores => Set<Actor>();
        public DbSet<Comentario> Comentarios => Set<Comentario>();
        public DbSet<Pelicula> Peliculas => Set<Pelicula>();
        public DbSet<PeliculaActor> PeliculasActores => Set<PeliculaActor>();

         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeedingInicial.Seed(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {

            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            // Otras configuraciones de tu DbContext

            base.OnConfiguring(optionsBuilder);
        }
    }
}
