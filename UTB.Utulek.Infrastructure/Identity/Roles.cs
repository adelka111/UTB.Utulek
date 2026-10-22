namespace UTB.Utulek.Infrastructure.Identity;

public static class Roles
{
    public const string Admin = "Admin";
    public const string Manager = "Manager";
    public const string Zakaznik = "Zakaznik";

    public static readonly string[] All = { Admin, Manager, Zakaznik };
}
