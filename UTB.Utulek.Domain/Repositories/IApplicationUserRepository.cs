using System.Security.Claims;
using UTB.Utulek.Domain.Interfaces;

namespace UTB.Utulek.Domain.Repositories;

public interface IApplicationUserRepository
{
    Task<IApplicationUser?> FindByEmail(string email);

    Task<IApplicationUser?> GetCurrentUser(ClaimsPrincipal principal);
}
