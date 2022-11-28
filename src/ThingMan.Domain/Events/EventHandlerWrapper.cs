using Microsoft.Extensions.DependencyInjection;
using ThingMan.Core;
using ThingMan.Core.Events;

namespace ThingMan.Domain.Events;

public abstract class EventHandlerWrapper
{
    public abstract Task<CoreResponse> Handle(IEvent @event, IServiceProvider serviceProvider);
}

public class EventHandlerWrapper<T> : EventHandlerWrapper
    where T : IEvent
{
    public override async Task<CoreResponse> Handle(IEvent @event, IServiceProvider serviceProvider)
    {
        var retval = CoreResponse.Success;

        try
        {
            var handlers = serviceProvider.GetServices<IHandleEvent<T>>();
            var coreResults = await Task.WhenAll(
                handlers.Select(he => he.HandleAsync((T)@event)));

            var coreErrors = coreResults.Where(cr => cr.Succeeded == false)
                .SelectMany(cr => cr.Errors);
            if (coreErrors.Any())
            {
                retval = CoreResponse.CreateFailedResponse(coreErrors.ToArray());
            }
        }
        catch (Exception e)
        {
            retval = CoreResponse.CreateFailedResponse(new CoreError { Message = e.Message });
        }

        return retval;
    }
}