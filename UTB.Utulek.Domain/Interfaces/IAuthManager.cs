using UTB.Utulek.Domain.Enums;

namespace UTB.Utulek.Domain.Interfaces;

public interface IAuthManager
{
    // Vrací chybové hlášky; null nebo prázdné pole znamená, že registrace proběhla.
    Task<string[]?> Register(IApplicationUser user, string password, params UserRole[] roles);

    Task<bool> Login(string userName, string password, bool rememberMe);

    Task Logout();
}
