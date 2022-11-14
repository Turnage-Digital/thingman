using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThingMan.Core.Events;

namespace ThingMan.Core;

public abstract class Entity
{
    private List<IEvent>? _events;

    [NotMapped]
    public IEnumerable<IEvent>? Events => _events?.AsReadOnly();

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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