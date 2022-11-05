using ThingMan.Core;
using ThingMan.Domain.Events;

namespace ThingMan.Domain.Entities;

public class ThingDef : Entity, IAggregateRoot
{
    public string UserId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public IList<PropDef> Props { get; set; } = null!;
    

    public static ThingDef Create(string userId, string name, IEnumerable<PropDef> props)
    {
        var retval = new ThingDef
        {
            UserId = userId,
            Name = name,
            Props = props.ToList()
        };
        retval.AddEvent(new ThingDefCreatedEvent(retval));
        return retval;
    }
}