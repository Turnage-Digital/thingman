using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Serilog;
using ThingMan.App.Extensions;
using ThingMan.Domain.Extensions;
using ThingMan.Domain.SqlDB.Extensions;
using ThingMan.Identity.SqlDB;
using ThingMan.Identity.SqlDB.Extensions;

namespace ThingMan;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
        builder.Services.AddDomainSqlDB(connectionString);
        builder.Services.AddIdentitySqlDB(connectionString);

        builder.Services
            .AddDefaultIdentity<IdentityUser>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        builder.Services
            .ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
            });

        builder.Services.AddDomain();
        
        builder.Services.AddAuthorization();
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