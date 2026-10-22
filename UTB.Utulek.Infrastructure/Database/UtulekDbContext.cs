using UTB.Utulek.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UTB.Utulek.Infrastructure.Database.Seeding;
using UTB.Utulek.Infrastructure.Identity;

namespace UTB.Utulek.Infrastructure.Database;

public class UtulekDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Animal> Animals { get; set; }
    public DbSet<Species> Species { get; set; }
    public DbSet<VirtualAdoption> VirtualAdoptions { get; set; }
    public DbSet<AnimalUpdate> AnimalUpdates { get; set; }

    public UtulekDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // VirtualAdoption.UserId -> ApplicationUser (bez navigační vlastnosti, Domain o Identity neví).
        // Délka 255 odpovídá sloupci AspNetUsers.Id, jinak MySQL cizí klíč nevytvoří (longtext).
        modelBuilder.Entity<VirtualAdoption>(entity =>
        {
            entity.Property(v => v.UserId).HasMaxLength(255);

            entity.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(v => v.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        });

        SpeciesInit speciesInit = new SpeciesInit();
        modelBuilder.Entity<Species>().HasData(speciesInit.GetSpecies());

        AnimalInit animalInit = new AnimalInit();
        modelBuilder.Entity<Animal>().HasData(animalInit.GetAnimals());
    }
}