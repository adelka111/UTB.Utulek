using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Domain.Validation;

namespace Domain.Entities;

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

    public int SpeciesId { get; set; }
    public Species? Species { get; set; }

    public ICollection<VirtualAdoption> VirtualAdoptions { get; set; } = new List<VirtualAdoption>();
    public ICollection<AnimalUpdate> Updates { get; set; } = new List<AnimalUpdate>();
}