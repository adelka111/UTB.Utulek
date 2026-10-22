using UTB.Utulek.Domain.Entities;
using UTB.Utulek.Domain.Repositories;
using UTB.Utulek.Infrastructure.Database;

namespace UTB.Utulek.Infrastructure.Repositories;

public class SpeciesRepository : Repository<Species, int>, ISpeciesRepository
{
    public SpeciesRepository(UtulekDbContext dbContext) : base(dbContext)
    {
    }
}
