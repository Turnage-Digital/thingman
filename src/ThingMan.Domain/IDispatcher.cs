using ThingMan.Core;
using ThingMan.Core.Events;

namespace ThingMan.Domain;

public interface IDispatcher
{
    Task<CoreResponse> RaiseAsync<T>(T @event)
        where T : IEvent;
}