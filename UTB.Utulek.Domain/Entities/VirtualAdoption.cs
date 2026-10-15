using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.Utulek.Domain.Entities;

[Table(nameof(VirtualAdoption))]
public class VirtualAdoption : BaseEntity
{
    [Range(50, 100000, ErrorMessage = "Měsíční příspěvek musí být 50 až 100 000 Kč.")]
    public decimal MonthlyAmount { get; set; }

    public DateTime StartDate { get; set; } = DateTime.UtcNow;

    public bool IsActive { get; set; } = true;

    [StringLength(500)]
    public string? Message { get; set; }

    public int AnimalId { get; set; }
    public Animal? Animal { get; set; }

    // Id uživatele z Identity. Samotný uživatel je v Infrastructure.
    public string UserId { get; set; } = string.Empty;
}