using ThingMan.Core.Domain.Events;

namespace ThingMan.Core.Domain.Entities;

public class ThingDef : Entity, IAggregateRoot
{
    protected ThingDef() { }

    public string Name { get; protected set; } = null!;

    public IList<PropDef> Props { get; protected set; } = null!;

    public static ThingDef Create(string name, IEnumerable<PropDef> props)
    {
        var retval = new ThingDef
        {
            Name = name,
            Props = props.ToList()
        };
        retval.AddEvent(new ThingDefCreatedEvent(retval));
        return retval;
    }
}