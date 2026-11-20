using System.Security.Claims;
using UTB.Utulek.Domain.Interfaces;

namespace UTB.Utulek.Application.Abstraction;

public interface ICurrentUserService
{
    Task<IApplicationUser?> GetCurrentUser(ClaimsPrincipal principal);
}
