using ThingMan.Core;
using ThingMan.Core.Events;

namespace ThingMan.Domain.Events.Handlers;

internal class ThingDefCreatedEventHandler : IHandleEvent<ThingDefCreatedEvent>
{
    public Task<CoreResponse> HandleAsync(ThingDefCreatedEvent @event)
    {
        
        return Task.FromResult(CoreResponse.Success);
    }

    public string Name => nameof(ThingDefCreatedEventHandler);
}