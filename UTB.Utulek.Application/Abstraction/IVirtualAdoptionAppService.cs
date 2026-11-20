using UTB.Utulek.Application.ViewModels;
using UTB.Utulek.Domain.Entities;

namespace UTB.Utulek.Application.Abstraction;

public interface IVirtualAdoptionAppService
{
    IList<VirtualAdoption> SelectForUser(string userId);

    // false, když zvíře neexistuje.
    bool Create(string userId, VirtualAdoptionCreateViewModel model);

    // false, když adopce neexistuje, nepatří uživateli nebo už je zrušená.
    bool Cancel(int id, string userId);
}
