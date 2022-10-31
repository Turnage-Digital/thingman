using ThingMan.Core.Domain.Entities;

namespace ThingMan.Core.Domain.Events;

public class ThingDefCreatedEvent : Event
{
    public ThingDefCreatedEvent(ThingDef thingDef)
    {
        ThingDef = thingDef;
    }

    public ThingDef ThingDef { get; }
}