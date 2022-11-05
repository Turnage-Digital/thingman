namespace ThingMan.Domain;

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