using Microsoft.Extensions.DependencyInjection;
using ThingMan.Core.Commands;
using ThingMan.Core.Events;
using ThingMan.Core.Queries;
using ThingMan.Domain.Aggregates.ThingDefs;
using ThingMan.Domain.Aggregates.ThingDefs.Commands;
using ThingMan.Domain.Aggregates.ThingDefs.Commands.Handlers;
using ThingMan.Domain.Aggregates.ThingDefs.Dtos;
using ThingMan.Domain.Aggregates.ThingDefs.Events;
using ThingMan.Domain.Aggregates.ThingDefs.Events.Handlers;
using ThingMan.Domain.Aggregates.ThingDefs.Queries;
using ThingMan.Domain.Aggregates.ThingDefs.Queries.Awaiters;
using ThingMan.Domain.Configuration;

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