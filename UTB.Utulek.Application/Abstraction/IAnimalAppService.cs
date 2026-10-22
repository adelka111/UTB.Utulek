using UTB.Utulek.Domain.Entities;

namespace UTB.Utulek.Application.Abstraction;

public interface IAnimalAppService
{
    IList<Animal> SelectAll();
    IList<Species> SelectAllSpecies();
    void Create(Animal animal);
    bool Delete(int id);
}
