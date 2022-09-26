using Boogops.Core.Domain.Repositories;
using Boogops.Core.MongoDB.Entities;
using MongoDB.Driver;

namespace Boogops.Core.MongoDB.Repositories;

public class ThingDefsRepository<TThingDef> : IThingDefsRepository<TThingDef>
    where TThingDef : ThingDef
{
    private readonly IMongoCollectionFacade<TThingDef> _thingDefsMongoCollection;

    public ThingDefsRepository(IGetThingDefsMongoCollection<TThingDef> getThingDefsMongoCollection)
    {
        _thingDefsMongoCollection = getThingDefsMongoCollection.Get();
    }

    public async Task<TThingDef?> ReadAsync(string id)
    {
        var filter = Builders<TThingDef>.Filter.Eq(x => x.Id, id);
        var retval = await _thingDefsMongoCollection.Find(filter)
            .SingleAsync();
        return retval;
    }

    public async Task<CoreResult> CreateAsync(TThingDef entity)
    {
        var retval = CoreResult.Success;

        try
        {
            await _thingDefsMongoCollection.InsertOneAsync(entity);
        }
        catch (Exception e)
        {
            retval = CoreResult.Failed(new CoreError { Message = e.Message });
        }

        return retval;
    }
}