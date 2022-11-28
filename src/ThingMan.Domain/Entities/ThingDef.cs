using ThingMan.Core;
using ThingMan.Domain.Events;

namespace ThingMan.Domain.Entities;

public class ThingDef : Entity, IAggregateRoot
{
    public string Name { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public IList<PropDef> Props { get; set; } = null!;

    public static ThingDef Create(string name, string userId, IEnumerable<PropDef> props)
    {
        var retval = new ThingDef
        {
            Name = name,
            UserId = userId,
            Props = props.ToList()
        };
        retval.AddEvent(new ThingDefCreatedEvent { ThingDef = retval });
        return retval;
    }
}