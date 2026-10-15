using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using UTB.Utulek.Domain.Repositories;
using UTB.Utulek.Infrastructure.Database;

namespace UTB.Utulek.Infrastructure.Repositories
{
    public class AnimalRepository : Repository<Animal, int>, IAnimalRepository
    {
        public AnimalRepository(UtulekDbContext dbContext) : base(dbContext)
        {
        }

        public IList<Animal> GetAllWithSpecies()
        {
            return dbSet.Include(a => a.Species).ToList();
        }
    }
}
