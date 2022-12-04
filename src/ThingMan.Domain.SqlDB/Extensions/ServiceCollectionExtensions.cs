using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ThingMan.Domain.Aggregates.ThingDefs;
using ThingMan.Domain.SqlDB.Aggregates.ThingDefs;

namespace ThingMan.Domain.SqlDB.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomainSqlDB(
        this IServiceCollection services,
        string connectionString
    )
    {
        var migrationAssemblyName = typeof(ThingManDbContext).Assembly.FullName!;

        services.AddDbContext<ThingManDbContext>(options =>
            options.UseSqlite(connectionString, optionsBuilder =>
                optionsBuilder.MigrationsAssembly(migrationAssemblyName)));

        services.AddRepositories();
        services.AddViews();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IThingDefsRepository, ThingDefsRepository>();
        return services;
    }

    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        services.AddScoped<IThingDefsView, ThingDefsView>();
        return services;
    }
}