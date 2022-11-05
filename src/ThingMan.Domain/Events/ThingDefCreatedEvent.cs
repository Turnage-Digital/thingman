using ThingMan.Domain.Entities;

namespace ThingMan.Domain.Events;

public class ThingDefCreatedEvent : Event
{
    public ThingDefCreatedEvent(ThingDef thingDef)
    {
        ThingDef = thingDef;
    }

    public ThingDef ThingDef { get; }
}