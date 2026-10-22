using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace UTB.Utulek.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    [StringLength(100)]
    public string FullName { get; set; } = string.Empty;
}
