using UTB.Utulek.Application.ViewModels;
using UTB.Utulek.Domain.Enums;

namespace UTB.Utulek.Application.Abstraction;

public interface IAuthService
{
    // Vrací chybové hlášky; null nebo prázdné pole znamená, že registrace proběhla.
    Task<string[]?> Register(RegisterViewModel model, params UserRole[] roles);

    Task<bool> Login(LoginViewModel model);

    Task Logout();
}
