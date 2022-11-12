using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ThingMan.Domain.SqlDB;

namespace ThingMan;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        const string databaseName = "thing-man.db";
        var migrationAssemblyName = typeof(ThingManDbContext).Assembly.FullName;
        
        builder.Services
            .AddDbContext<ThingManDbContext>(options =>
                options.UseSqlite(databaseName,
                    optionsBuilder => optionsBuilder.MigrationsAssembly(migrationAssemblyName)));

        builder.Services
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(databaseName));

        builder.Services
            .AddDefaultIdentity<IdentityUser>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHsts();
        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseRouting();

        app.UseAuthentication();

        return app;
    }
}