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

    public Animal? GetById(int id)
    {
        return _animalRepository.GetByIdWithSpecies(id);
    }

    public void Create(Animal animal)
    {
        _animalRepository.Add(animal);
    }

    public bool Update(Animal animal)
    {
        Animal? existing = _animalRepository.GetById(animal.Id);
        if (existing == null)
        {
            return false;
        }

        // Přepisují se jen pole z formuláře, ostatní (např. ImageFileName) zůstávají.
        existing.Name = animal.Name;
        existing.Breed = animal.Breed;
        existing.BirthDate = animal.BirthDate;
        existing.Gender = animal.Gender;
        existing.Description = animal.Description;
        existing.SpeciesId = animal.SpeciesId;
        existing.OtherSpeciesName = animal.OtherSpeciesName;

        _animalRepository.Edit(existing);
        return true;
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
