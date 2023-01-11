using Microsoft.Extensions.DependencyInjection;
using ThingMan.Domain.Aggregates.ThingDefs.Extensions;
using ThingMan.Domain.Configuration;

namespace ThingMan.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddAutoMapper(config => { config.AddProfile<DomainMappingProfile>(); });
        services.AddScoped<IDispatcher, Dispatcher>();
        services.AddThingDefs();

        return services;
    }
}