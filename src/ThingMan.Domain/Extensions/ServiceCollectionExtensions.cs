using Microsoft.Extensions.DependencyInjection;
using ThingMan.Core.Commands;
using ThingMan.Core.Events;
using ThingMan.Core.Queries;
using ThingMan.Domain.Commands;
using ThingMan.Domain.Commands.Handlers;
using ThingMan.Domain.Configuration;
using ThingMan.Domain.Dtos;
using ThingMan.Domain.Entities;
using ThingMan.Domain.Events;
using ThingMan.Domain.Events.Handlers;
using ThingMan.Domain.Queries;
using ThingMan.Domain.Queries.Awaiters;

namespace ThingMan.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddAutoMapper(config => { config.AddProfile<DomainMappingProfile>(); });
        services.AddScoped<IDispatcher, Dispatcher>();
        services.AddCommandHandlers();
        services.AddEventHandlers();
        services.AddQueryAwaiters();
        return services;
    }

    public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
    {
        services.AddScoped<IHandleCommand<CreateThingDefCommand, ThingDef>, 
            CreateThingDefCommandHandler>();
        return services;
    }

    public static IServiceCollection AddEventHandlers(this IServiceCollection services)
    {
        services.AddScoped<IHandleEvent<ThingDefCreatedEvent>,
            ThingDefCreatedEventHandler>();
        return services;
    }

    public static IServiceCollection AddQueryAwaiters(this IServiceCollection services)
    {
        services.AddScoped<IAwaitQuery<GetThingDefByIdQuery, ThingDefDto>, 
            GetThingDefByIdQueryAwaiter>();
        return services;
    }
}