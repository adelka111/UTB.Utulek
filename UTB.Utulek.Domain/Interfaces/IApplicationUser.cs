namespace UTB.Utulek.Domain.Interfaces;

// Uživatel útulku tak, jak ho vidí doména. Implementuje ho třída v Infrastructure.
public interface IApplicationUser
{
    string Id { get; }
    string? UserName { get; set; }
    string? Email { get; set; }
    string? FullName { get; set; }
}
