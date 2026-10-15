using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using UTB.Utulek.Infrastructure.Database.Seeding;

namespace UTB.Utulek.Infrastructure.Database
{
    public class UtulekDbContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Species> Species { get; set; }

        public UtulekDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SpeciesInit speciesInit = new SpeciesInit();
            modelBuilder.Entity<Species>().HasData(speciesInit.GetSpecies());

            AnimalInit animalInit = new AnimalInit();
            modelBuilder.Entity<Animal>().HasData(animalInit.GetAnimals());
        }
    }
}