using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using UTB.Utulek.Domain.Interfaces;

namespace UTB.Utulek.Infrastructure.Identity;

public class ApplicationUser : IdentityUser, IApplicationUser
{
    [StringLength(100)]
    public string FullName { get; set; } = string.Empty;

    // Rozhraní připouští null, sloupec v databázi ale zůstává povinný.
    string? IApplicationUser.FullName
    {
        get => FullName;
        set => FullName = value ?? string.Empty;
    }
}
