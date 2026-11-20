using UTB.Utulek.Infrastructure.Identity;

namespace UTB.Utulek.Infrastructure.Database.Seeding;

internal class UserInit
{
    public const string AdminId = "cfe1b584-c967-4c7f-81b2-89f8db220194";

    // Jen hash vygenerovaný přes PasswordHasher<ApplicationUser>, heslo samotné se do kódu nepíše.
    private const string AdminPasswordHash = "AQAAAAIAAYagAAAAEPjzRiWsnOQ9PXKLHwVKLCOz37SXhsmU1BIAX+gzYDF+4NEQSei8xVi5Iipv0gChyg==";

    public IList<ApplicationUser> GetUsers()
    {
        IList<ApplicationUser> users = new List<ApplicationUser>();

        users.Add(new ApplicationUser
        {
            Id = AdminId,
            UserName = "admin@utulek.cz",
            NormalizedUserName = "ADMIN@UTULEK.CZ",
            Email = "admin@utulek.cz",
            NormalizedEmail = "ADMIN@UTULEK.CZ",
            EmailConfirmed = true,
            FullName = "Administrátor",
            PasswordHash = AdminPasswordHash,
            SecurityStamp = "46324865-59f9-4aec-a4f7-383ded4e7391",
            ConcurrencyStamp = "02bedc5f-d351-4465-9e60-b4a9d71144eb",
            LockoutEnabled = true
        });

        return users;
    }
}
