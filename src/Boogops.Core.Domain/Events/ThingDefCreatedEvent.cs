using Boogops.Core.Domain.Entities;

namespace Boogops.Core.Domain.Events;

public class ThingDefCreatedEvent : Event
{
    public ThingDefCreatedEvent(ThingDef thingDef)
    {
        ThingDef = thingDef;
    }

    public ThingDef ThingDef { get; }
}