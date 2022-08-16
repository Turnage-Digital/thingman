namespace Boogops.Core.Domain.Entities;

public class ThingDef : Entity, IAggregateRoot
{
    public IList<PropDef>? PropDefs { get; set; }
}