using Serilog;
using ThingMan.Core.Events;
using ThingMan.Domain;

namespace ThingMan.App.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseApp(this WebApplication app)
    {
        app.UseDispatch();
        app.MapThingDefsApi();
        return app;
    }

    public static WebApplication UseDispatch(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var eventHandlers = scope.ServiceProvider.GetServices<IHandleEvent>();

        foreach (var eventHandler in eventHandlers)
        {
            Log.Information("Dispatch handler {Name} is loaded", eventHandler.Name);
            Dispatcher.Register(eventHandler);
        }

        return app;
    }
}