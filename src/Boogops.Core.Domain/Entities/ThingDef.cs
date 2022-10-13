namespace Boogops.Core.Domain.Entities;

public class ThingDef : Entity, IAggregateRoot
{
    public string Name { get; set; } = string.Empty;

    public IList<PropDef> Props { get; } = new List<PropDef>();
}