using Microsoft.EntityFrameworkCore;
using UTB.Utulek.Domain.Entities;
using UTB.Utulek.Domain.Repositories;
using UTB.Utulek.Infrastructure.Database;

namespace UTB.Utulek.Infrastructure.Repositories;

public class VirtualAdoptionRepository : Repository<VirtualAdoption, int>, IVirtualAdoptionRepository
{
    public VirtualAdoptionRepository(UtulekDbContext dbContext) : base(dbContext)
    {
    }

    // Adopce jednoho uživatele i se zvířetem a jeho druhem, nejnovější nahoře.
    public IList<VirtualAdoption> GetByUserWithAnimal(string userId)
    {
        return dbSet
            .Include(v => v.Animal)
                .ThenInclude(a => a!.Species)
            .Where(v => v.UserId == userId)
            .OrderByDescending(v => v.StartDate)
            .ToList();
    }
}
