using UTB.Utulek.Application.Abstraction;
using UTB.Utulek.Application.ViewModels;
using UTB.Utulek.Domain.Enums;
using UTB.Utulek.Domain.Interfaces;

namespace UTB.Utulek.Application.Implementation;

public class AuthService : IAuthService
{
    private readonly IAuthManager _authManager;

    public AuthService(IAuthManager authManager)
    {
        _authManager = authManager;
    }

    public Task<string[]?> Register(RegisterViewModel model, params UserRole[] roles)
    {
        // E-mail slouží zároveň jako uživatelské jméno, přihlášení pak probíhá e-mailem.
        NewUser user = new NewUser
        {
            UserName = model.Email,
            Email = model.Email,
            FullName = model.FullName
        };

        return _authManager.Register(user, model.Password, roles);
    }

    public Task<bool> Login(LoginViewModel model)
    {
        return _authManager.Login(model.Email, model.Password, model.RememberMe);
    }

    public Task Logout()
    {
        return _authManager.Logout();
    }

    // Údaje nového uživatele pro IAuthManager. Id přidělí až Infrastructure při vytvoření účtu.
    private class NewUser : IApplicationUser
    {
        public string Id { get; } = string.Empty;
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
    }
}
