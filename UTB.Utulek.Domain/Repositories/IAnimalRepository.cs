using UTB.Utulek.Domain.Entities;

namespace UTB.Utulek.Domain.Repositories;

public interface IAnimalRepository : IRepository<Animal, int>
{
    IList<Animal> GetAllWithSpecies();
}
