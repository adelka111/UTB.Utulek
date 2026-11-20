using Microsoft.AspNetCore.Identity;
using UTB.Utulek.Domain.Enums;

namespace UTB.Utulek.Infrastructure.Database.Seeding;

internal class RoleInit
{
    // Pevná Id a ConcurrencyStamp, aby HasData při každé migraci negenerovalo nové hodnoty.
    public const string AdminRoleId = "5eb05733-a760-4701-b023-3a4320286069";
    public const string ManagerRoleId = "28308a6d-0b6b-42be-9bd0-3353de6fedd5";
    public const string CustomerRoleId = "cad2816b-23b6-476b-9a57-2873678dddf0";

    public IList<IdentityRole> GetRoles()
    {
        IList<IdentityRole> roles = new List<IdentityRole>();

        roles.Add(CreateRole(AdminRoleId, UserRole.Admin, "7970aed5-0ade-4c89-b9e7-47e72341657f"));
        roles.Add(CreateRole(ManagerRoleId, UserRole.Manager, "9cadda5d-6111-47c1-8578-12995cfc8e37"));
        roles.Add(CreateRole(CustomerRoleId, UserRole.Customer, "0f5325cd-bf71-49e7-9c50-f9d93cd73737"));

        return roles;
    }

    private static IdentityRole CreateRole(string id, UserRole role, string concurrencyStamp)
    {
        string name = role.ToString();

        return new IdentityRole
        {
            Id = id,
            Name = name,
            NormalizedName = name.ToUpperInvariant(),
            ConcurrencyStamp = concurrencyStamp
        };
    }
}
