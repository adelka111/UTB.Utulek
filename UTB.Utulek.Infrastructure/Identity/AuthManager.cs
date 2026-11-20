using Microsoft.AspNetCore.Identity;
using UTB.Utulek.Domain.Enums;
using UTB.Utulek.Domain.Interfaces;

namespace UTB.Utulek.Infrastructure.Identity;

public class AuthManager : IAuthManager
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthManager(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<string[]?> Register(IApplicationUser user, string password, params UserRole[] roles)
    {
        // Web může poslat přímo ApplicationUser, jinak se z údajů rozhraní vytvoří nový.
        ApplicationUser applicationUser = user as ApplicationUser ?? new ApplicationUser
        {
            UserName = user.UserName,
            Email = user.Email,
            FullName = user.FullName ?? string.Empty
        };

        IdentityResult result = await _userManager.CreateAsync(applicationUser, password);
        if (!result.Succeeded)
        {
            return GetErrors(result);
        }

        if (roles.Length > 0)
        {
            IEnumerable<string> roleNames = roles.Distinct().Select(r => r.ToString());
            result = await _userManager.AddToRolesAsync(applicationUser, roleNames);
            if (!result.Succeeded)
            {
                // Uživatel bez požadovaných rolí by v aplikaci neměl zůstat.
                await _userManager.DeleteAsync(applicationUser);
                return GetErrors(result);
            }
        }

        return null;
    }

    public async Task<bool> Login(string userName, string password, bool rememberMe)
    {
        SignInResult result = await _signInManager.PasswordSignInAsync(userName, password, rememberMe, lockoutOnFailure: false);
        return result.Succeeded;
    }

    public Task Logout()
    {
        return _signInManager.SignOutAsync();
    }

    private static string[] GetErrors(IdentityResult result)
    {
        return result.Errors.Select(e => e.Description).ToArray();
    }
}
