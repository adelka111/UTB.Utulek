using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using UTB.Utulek.Domain.Interfaces;
using UTB.Utulek.Domain.Repositories;
using UTB.Utulek.Infrastructure.Identity;

namespace UTB.Utulek.Infrastructure.Repositories;

public class ApplicationUserRepository : IApplicationUserRepository
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ApplicationUserRepository(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IApplicationUser?> FindByEmail(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<IApplicationUser?> GetCurrentUser(ClaimsPrincipal principal)
    {
        return await _userManager.GetUserAsync(principal);
    }
}
