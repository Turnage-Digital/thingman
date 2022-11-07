using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace ThingMan;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("Default");
        builder.Services
            .AddDbContext<IdentityDbContext<IdentityUser>>(options =>
                options.UseCosmos(connectionString, "ThingMan"));

        builder.Services
            .AddDefaultIdentity<IdentityUser>()
            .AddEntityFrameworkStores<IdentityDbContext<IdentityUser>>();

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