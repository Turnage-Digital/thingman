using ThingMan.Core.Events;

namespace ThingMan.Domain;

public abstract class Entity
{
    private List<IEvent>? _events;

    public IEnumerable<IEvent>? Events => _events?.AsReadOnly();

    public string? Id { get; set; } = null;

    public void AddEvent(IEvent eventItem)
    {
        _events ??= new List<IEvent>();
        _events.Add(eventItem);
    }

    public void RemoveEvent(IEvent eventItem)
    {
        _events?.Remove(eventItem);
    }

    public void ClearEvents()
    {
        _events?.Clear();
    }
}

public static class EntityExtensions
{
    public static async Task DispatchEventsAsync(this Entity entity)
    {
        var events = entity.Events?.ToList();
        if (events is not null)
        {
            entity.ClearEvents();
            foreach (var @event in events)
            {
                var result = await Dispatcher.RaiseAsync(@event);
                if (!result.Succeeded) { }
            }
        }
    }
}