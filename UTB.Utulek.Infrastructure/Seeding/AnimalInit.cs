using Domain.Entities;
using Domain.Enums;

namespace UTB.Utulek.Infrastructure.Database.Seeding
{
    internal class AnimalInit
    {
        public IList<Animal> GetAnimals()
        {
            IList<Animal> animals = new List<Animal>();

            animals.Add(new Animal
            {
                Id = 1,
                Name = "Rex",
                Breed = "Kříženec",
                BirthDate = new DateTime(2021, 3, 15),
                Gender = Gender.Male,
                Description = "Přátelský pes, má rád dlouhé procházky.",
                ImageFileName = "/img/animals/rex.jpg",
                SpeciesId = 1
            });
            animals.Add(new Animal
            {
                Id = 2,
                Name = "Micka",
                Breed = "Evropská krátkosrstá",
                BirthDate = new DateTime(2022, 7, 2),
                Gender = Gender.Female,
                Description = "Klidná kočka, vhodná i do bytu.",
                ImageFileName = "/img/animals/micka.jpg",
                SpeciesId = 2
            });
            animals.Add(new Animal
            {
                Id = 3,
                Name = "Bob",
                Breed = "Králík domácí",
                BirthDate = new DateTime(2023, 1, 20),
                Gender = Gender.Male,
                Description = "Mladý králík, zvyklý na děti.",
                ImageFileName = "/img/animals/bob.jpg",
                SpeciesId = 3
            });

            return animals;
        }
    }
}