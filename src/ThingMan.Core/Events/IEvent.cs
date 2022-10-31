namespace ThingMan.Core.Events;

public interface IEvent
{
    Guid TraceId { get; set; }
}