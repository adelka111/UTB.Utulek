using UTB.Utulek.Domain.Entities;
using UTB.Utulek.Application.Abstraction;
using UTB.Utulek.Domain.Repositories;

namespace UTB.Utulek.Application.Implementation;

public class AnimalAppService : IAnimalAppService
{
    private readonly IAnimalRepository _animalRepository;
    private readonly ISpeciesRepository _speciesRepository;

    public AnimalAppService(IAnimalRepository animalRepository, ISpeciesRepository speciesRepository)
    {
        _animalRepository = animalRepository;
        _speciesRepository = speciesRepository;
    }

    public IList<Animal> SelectAll()
    {
        return _animalRepository.GetAllWithSpecies();
    }

    public IList<Species> SelectAllSpecies()
    {
        return _speciesRepository.GetAll().OrderBy(s => s.Name).ToList();
    }

    public void Create(Animal animal)
    {
        _animalRepository.Add(animal);
    }

    public bool Delete(int id)
    {
        Animal? animal = _animalRepository.GetById(id);
        if (animal == null)
        {
            return false;
        }

        _animalRepository.Delete(animal);
        return true;
    }
}
