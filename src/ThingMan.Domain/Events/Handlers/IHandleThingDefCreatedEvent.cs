using ThingMan.Core.Events;

namespace ThingMan.Domain.Events.Handlers;

public interface IHandleThingDefCreatedEvent :
    IHandleEvent<ThingDefCreatedEvent> { }