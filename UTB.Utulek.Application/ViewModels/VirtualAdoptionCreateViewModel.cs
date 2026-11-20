using System.ComponentModel.DataAnnotations;

namespace UTB.Utulek.Application.ViewModels;

// Formulář nové adopce. Záměrně neobsahuje UserId, uživatele určuje přihlášení.
public class VirtualAdoptionCreateViewModel
{
    public int AnimalId { get; set; }

    // Jen pro zobrazení ve formuláři, při uložení se nepoužívá.
    public string? AnimalName { get; set; }

    // Celé koruny, aby nevadila desetinná čárka/tečka ve formuláři.
    [Range(50, 100000, ErrorMessage = "Měsíční příspěvek musí být 50 až 100 000 Kč.")]
    public int MonthlyAmount { get; set; } = 200;

    [StringLength(500, ErrorMessage = "Vzkaz může mít nejvýše 500 znaků.")]
    public string? Message { get; set; }
}
