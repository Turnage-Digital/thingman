using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ThingMan.Domain.Repositories;
using ThingMan.Domain.SqlDB.Repositories;

namespace ThingMan.Domain.SqlDB.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomainSqlDB(
        this IServiceCollection services,
        string connectionString,
        string migrationAssemblyName
    )
    {
        services.AddDbContext<ThingManDbContext>(options =>
            options.UseSqlite(connectionString, optionsBuilder =>
                optionsBuilder.MigrationsAssembly(migrationAssemblyName)));

        services.AddRepositories();
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IThingDefsRepository, ThingDefsRepository>();
        return services;
    }
}