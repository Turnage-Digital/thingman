using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThingMan.Domain.Aggregates.ThingDefs;

public record PropDef
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string? Id { get; set; } = null;
    
    public string Name { get; set; } = null!;
    
    public string PropType { get; set; } = null!;
}