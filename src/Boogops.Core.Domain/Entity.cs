using Boogops.Core.Events;

namespace Boogops.Core.Domain;

public abstract class Entity
{
    private List<IEvent>? _events;

    public IEnumerable<IEvent>? Events => _events?.AsReadOnly();

    public void AddEvent(IEvent eventItem)
    {
        _events ??= new List<IEvent>();
        _events.Add(eventItem);
    }

    public void RemoveEvent(IEvent eventItem)
    {
        _events?.Remove(eventItem);
    }

    public async Task DispatchEventsAsync()
    {
        var events = Events?.ToList();
        if (events is not null)
        {
            _events?.Clear();
            foreach (var @event in events)
            {
                var result = await Dispatcher.RaiseAsync(@event);
                if (!result.Succeeded) { }
            }
        }
    }
}