using System.ComponentModel.DataAnnotations;


namespace UTB.Utulek.Domain.Entities;

public class Species : BaseEntity
{
    [Required(ErrorMessage = "Název druhu je povinný.")]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    public ICollection<Animal> Animals { get; set; } = new List<Animal>();
}