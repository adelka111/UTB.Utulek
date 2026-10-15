using Domain.Entities;
using UTB.Utulek.Application.Abstraction;
using UTB.Utulek.Domain.Repositories;

namespace UTB.Utulek.Application.Implementation
{
    public class AnimalAppService : IAnimalAppService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalAppService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public IList<Animal> SelectAll()
        {
            return _animalRepository.GetAllWithSpecies();
        }
    }
}
