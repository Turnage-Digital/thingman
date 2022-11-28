using ThingMan.Core;
using ThingMan.Core.Events;

namespace ThingMan.Domain.Events.Handlers;

public class ThingDefCreatedEventHandler : IHandleEvent<ThingDefCreatedEvent>
{
    public async Task<CoreResponse> HandleAsync(ThingDefCreatedEvent @event)
    {
        throw new NotImplementedException();
    }

    public string Name => nameof(ThingDefCreatedEventHandler);
}