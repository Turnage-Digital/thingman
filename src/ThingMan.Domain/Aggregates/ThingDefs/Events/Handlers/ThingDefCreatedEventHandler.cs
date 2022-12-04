using Serilog;
using ThingMan.Core;
using ThingMan.Core.Events;

namespace ThingMan.Domain.Aggregates.ThingDefs.Events.Handlers;

internal class ThingDefCreatedEventHandler : IHandleEvent<ThingDefCreatedEvent>
{
    public Task<CoreResponse> HandleAsync(ThingDefCreatedEvent @event)
    {
        Log.Information("Received event: {TraceId} {Event}", @event.TraceId, @event);
        return Task.FromResult(CoreResponse.Success);
    }

    public string Name => nameof(ThingDefCreatedEventHandler);
}