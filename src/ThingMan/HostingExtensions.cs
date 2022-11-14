using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using ThingMan.App.Extensions;
using ThingMan.Domain.SqlDB;
using ThingMan.Domain.SqlDB.Extensions;
using ThingMan.Identity.SqlDB;
using ThingMan.Identity.SqlDB.Extensions;

namespace ThingMan;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

        var domainAssemblyName = typeof(ThingManDbContext).Assembly.FullName!;
        builder.Services.AddDomainSqlDB(connectionString, domainAssemblyName);
        
        var identityAssemblyName = typeof(ApplicationDbContext).Assembly.FullName!;
        builder.Services.AddIdentitySqlDB(connectionString, identityAssemblyName);

        builder.Services
            .AddDefaultIdentity<IdentityUser>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        builder.Services.ConfigureApplicationCookie(options => { options.LoginPath = "/Account/Login"; });
        
        builder.Services.AddAuthorization();

        builder.Services.AddApp();
        builder.Services.AddRazorPages();

        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddEndpointsApiExplorer()
                .AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "ThingMan"
                    });
                });
        }

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHsts();
        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseApp();

        app.MapRazorPages()
            .RequireAuthorization();

        return app;
    }
}