using System.ComponentModel.DataAnnotations;
using ThingMan.Core;
using ThingMan.Domain.Aggregates.ThingDefs.Events;

namespace ThingMan.Domain.Aggregates.ThingDefs;

public class ThingDef : Entity, IAggregateRoot
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string UserId { get; set; } = null!;

    public PropDef? PropDef1 { get; set; }

    public PropDef? PropDef2 { get; set; }

    public PropDef? PropDef3 { get; set; }

    public static ThingDef Create(
        string name,
        string userId,
        PropDef? propDef1 = null,
        PropDef? propDef2 = null,
        PropDef? propDef3 = null
    )
    {
        var retval = new ThingDef
        {
            Name = name,
            UserId = userId,
            PropDef1 = propDef1,
            PropDef2 = propDef2,
            PropDef3 = propDef3
        };
        retval.AddEvent(new ThingDefCreatedEvent { ThingDef = retval });
        return retval;
    }
}