namespace ThingMan.App.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseApp(this WebApplication app)
    {
        app.MapThingDefsApi();
        return app;
    }
}