using ThingMan.Domain.Commands.Handlers;
using ThingMan.Domain.Configuration;

namespace ThingMan.App.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApp(this IServiceCollection services)
    {
        services.AddAutoMapper(config => { config.AddProfile<DomainMappingProfile>(); });

        services.AddCommandHandlers();
        services.AddEventHandlers();
        services.AddQueryAwaiters();
        return services;
    }

    public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
    {
        services.AddScoped<IHandleCreateThingDefCommand, CreateThingDefCommandHandler>();
        return services;
    }

    public static IServiceCollection AddEventHandlers(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddQueryAwaiters(this IServiceCollection services)
    {
        return services;
    }
}