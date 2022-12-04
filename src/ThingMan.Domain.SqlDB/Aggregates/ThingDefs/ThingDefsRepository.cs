using Microsoft.EntityFrameworkCore;
using ThingMan.Domain.Aggregates.ThingDefs;

namespace ThingMan.Domain.SqlDB.Aggregates.ThingDefs;

internal class ThingDefsRepository : IThingDefsRepository
{
    private readonly ThingManDbContext _dbContext;

    public ThingDefsRepository(ThingManDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ThingDef?> ReadAsync(string id)
    {
        var retval = await _dbContext.ThingDefs
            .Where(r => r.Id == id)
            .SingleOrDefaultAsync();
        return retval;
    }

    public async Task CreateAsync(ThingDef entity)
    {
        _dbContext.ThingDefs.Add(entity);
        await _dbContext.SaveChangesAsync();
    }
}