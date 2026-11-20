using System.Security.Claims;
using UTB.Utulek.Application.Abstraction;
using UTB.Utulek.Domain.Interfaces;
using UTB.Utulek.Domain.Repositories;

namespace UTB.Utulek.Application.Implementation;

public class CurrentUserService : ICurrentUserService
{
    private readonly IApplicationUserRepository _userRepository;

    public CurrentUserService(IApplicationUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<IApplicationUser?> GetCurrentUser(ClaimsPrincipal principal)
    {
        return _userRepository.GetCurrentUser(principal);
    }
}
