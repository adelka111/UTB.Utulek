using System.ComponentModel.DataAnnotations;

namespace UTB.Utulek.Domain.Entities;

public class AnimalUpdate : BaseEntity
{
    [Required(ErrorMessage = "Nadpis je povinný.")]
    [StringLength(150)]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Text je povinný.")]
    [StringLength(2000)]
    public string Text { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int AnimalId { get; set; }
    public Animal? Animal { get; set; }
}