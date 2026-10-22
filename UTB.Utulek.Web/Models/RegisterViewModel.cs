using System.ComponentModel.DataAnnotations;

namespace UTB.Utulek.Web.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Jméno a příjmení je povinné.")]
    [StringLength(100)]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "E-mail je povinný.")]
    [EmailAddress(ErrorMessage = "Zadejte platný e-mail.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Heslo je povinné.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Zopakujte heslo.")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Hesla se neshodují.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
