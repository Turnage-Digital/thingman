using ThingMan.Core.Events;

namespace ThingMan.Core.Domain.Events.Handlers;

public interface IHandleThingDefCreatedEvent :
    IHandleEvent<ThingDefCreatedEvent> { }