using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace UTB.Utulek.Infrastructure.Identity;

public static class RoleSeeder
{
    // Vytvoří role Admin, Manager a Zakaznik, pokud v databázi ještě nejsou.
    public static async Task SeedRolesAsync(IServiceProvider services)
    {
        RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        foreach (string role in Roles.All)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
