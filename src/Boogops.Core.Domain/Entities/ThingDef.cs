using Boogops.Core.Domain.Events;

namespace Boogops.Core.Domain.Entities;

public class ThingDef : Entity, IAggregateRoot
{
    protected ThingDef() { }
    
    public string Name { get; protected set; } = null!;

    public IList<PropDef> Props { get; protected set; } = null!;
    
    public static ThingDef Create(string name, IList<PropDef> props)
    {
        var retval = new ThingDef
        {
            Id = null,
            Name = null,
            Props = null
        };
        retval.Name = name;
        foreach (var prop in props)
            retval.Props.Add(prop);
        retval.AddEvent(new ThingDefCreatedEvent(retval));
        return retval;
    }
}