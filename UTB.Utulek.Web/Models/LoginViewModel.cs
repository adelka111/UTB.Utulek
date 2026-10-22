using System.ComponentModel.DataAnnotations;

namespace UTB.Utulek.Web.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "E-mail je povinný.")]
    [EmailAddress(ErrorMessage = "Zadejte platný e-mail.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Heslo je povinné.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    public bool RememberMe { get; set; }
}
