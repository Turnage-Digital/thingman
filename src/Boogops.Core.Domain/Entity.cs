using Boogops.Core.Events;

namespace Boogops.Core.Domain;

public abstract class Entity
{
    private List<IEvent>? _events;

    public IReadOnlyCollection<IEvent>? Events => _events?.AsReadOnly();

    public void AddEvent(IEvent eventItem)
    {
        _events = _events ?? new List<IEvent>();
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