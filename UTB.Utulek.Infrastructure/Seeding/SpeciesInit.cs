using Domain.Entities;

namespace UTB.Utulek.Infrastructure.Database.Seeding
{
    internal class SpeciesInit
    {
        public IList<Species> GetSpecies()
        {
            IList<Species> species = new List<Species>();

            species.Add(new Species { Id = 1, Name = "Pes" });
            species.Add(new Species { Id = 2, Name = "Kočka" });
            species.Add(new Species { Id = 3, Name = "Králík" });

            return species;
        }
    }
}