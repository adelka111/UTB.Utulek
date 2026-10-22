using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Utulek.Domain.Enums;
using UTB.Utulek.Domain.Validation;

namespace UTB.Utulek.Domain.Entities;

[Table(nameof(Animal))]
public class Animal : BaseEntity
{
    [Required(ErrorMessage = "Jméno je povinné.")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(100)]
    public string? Breed { get; set; }

    [NotInFuture(ErrorMessage = "Datum narození nesmí být v budoucnosti.")]
    public DateTime BirthDate { get; set; }

    public Gender Gender { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    public string? ImageFileName { get; set; }

    // Druh z nabídky (Kočka, Králík, Pes). U druhu "Jiné" je null a název je v OtherSpeciesName.
    public int? SpeciesId { get; set; }
    public Species? Species { get; set; }

    [StringLength(50, ErrorMessage = "Název druhu může mít nejvýše 50 znaků.")]
    public string? OtherSpeciesName { get; set; }

    public ICollection<VirtualAdoption> VirtualAdoptions { get; set; } = new List<VirtualAdoption>();
    public ICollection<AnimalUpdate> Updates { get; set; } = new List<AnimalUpdate>();
}