using ThingMan.Core;
using ThingMan.Core.Events;

namespace ThingMan.Domain.Events;

public interface IDispatcher
{
    Task<CoreResponse> RaiseAsync<T>(T @event)
        where T : IEvent;
}

internal class Dispatcher : IDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public Dispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<CoreResponse> RaiseAsync<T>(T @event)
        where T : IEvent
    {
        CoreResponse retval;

        try
        {
            var wrapper = (EventHandlerWrapper)Activator
                .CreateInstance(typeof(EventHandlerWrapper<>)
                    .MakeGenericType(@event.GetType()))!;
            retval = await wrapper.Handle(@event, _serviceProvider);
        }
        catch (Exception e)
        {
            retval = CoreResponse.CreateFailedResponse(new CoreError { Message = e.Message });
        }

        return retval;
    }
}