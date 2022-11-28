using Microsoft.EntityFrameworkCore;
using Serilog;
using ThingMan.Core;
using ThingMan.Domain.Entities;
using ThingMan.Domain.Events;

namespace ThingMan.Domain.SqlDB;

public class ThingManDbContext : DbContext
{
    private readonly IDispatcher _dispatcher;

    public ThingManDbContext(DbContextOptions<ThingManDbContext> options, IDispatcher dispatcher)
        : base(options)
    {
        _dispatcher = dispatcher;
    }

    public virtual DbSet<ThingDef> ThingDefs { get; set; } = null!;

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var retval = await base.SaveChangesAsync(cancellationToken);
        await DispatchEventsAsync();
        return retval;
    }

    private async Task DispatchEventsAsync()
    {
        var entities = ChangeTracker
            .Entries<Entity>()
            .Where(entity => entity.Entity.Events != null && entity.Entity.Events.Any())
            .ToList();

        var events = entities
            .SelectMany(entry => entry.Entity.Events!)
            .ToList();

        foreach (var entity in entities)
        {
            entity.Entity.ClearEvents();
        }

        foreach (var @event in events)
        {
            var result = await _dispatcher.RaiseAsync(@event);
            if (!result.Succeeded)
            {
                var message = result.Errors
                    .Aggregate($"Event: {@event} - failed:", (m, coreError) => $"{m} {coreError.Message}");
                Log.Error("{message}", message);
            }
        }
    }
}