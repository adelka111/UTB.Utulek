using Microsoft.AspNetCore.Identity;

namespace UTB.Utulek.Infrastructure.Database.Seeding;

internal class UserRoleInit
{
    public IList<IdentityUserRole<string>> GetUserRoles()
    {
        IList<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

        // Administrátor má všechny tři role.
        userRoles.Add(new IdentityUserRole<string> { UserId = UserInit.AdminId, RoleId = RoleInit.AdminRoleId });
        userRoles.Add(new IdentityUserRole<string> { UserId = UserInit.AdminId, RoleId = RoleInit.ManagerRoleId });
        userRoles.Add(new IdentityUserRole<string> { UserId = UserInit.AdminId, RoleId = RoleInit.CustomerRoleId });

        return userRoles;
    }
}
