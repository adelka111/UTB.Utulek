using UTB.Utulek.Domain.Entities;

namespace UTB.Utulek.Domain.Repositories;

public interface IVirtualAdoptionRepository : IRepository<VirtualAdoption, int>
{
    IList<VirtualAdoption> GetByUserWithAnimal(string userId);
}
