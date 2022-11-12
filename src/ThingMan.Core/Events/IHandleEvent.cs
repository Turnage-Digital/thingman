namespace ThingMan.Core.Events;

public interface IHandleEvent
{
    public string Name { get; }
}

public interface IHandleEvent<in T> : IHandleEvent
    where T : IEvent
{
    Task<CoreResponse> HandleAsync(T @event);
}