using MongoDB.Driver;
using ThingMan.Core;
using ThingMan.DocDB;
using ThingMan.Domain.Entities;
using ThingMan.Domain.Repositories;

namespace ThingMan.Domain.DocDB.Repositories;

public class ThingDefsRepository : IThingDefsRepository<ThingDef>
{
    private const string COLLECTION = "ThingDefs";

    private readonly IMongoCollection<ThingDef> _thingDefsMongoCollection;

    public ThingDefsRepository(IGetDocDBCollection getDocDbCollection)
    {
        _thingDefsMongoCollection = getDocDbCollection.Get<ThingDef>(COLLECTION);
    }

    public async Task<ThingDef?> ReadAsync(string id)
    {
        var filter = Builders<ThingDef>.Filter.Eq(x => x.Id, id);
        var retval = await _thingDefsMongoCollection.Find(filter)
            .SingleAsync();
        return retval;
    }

    public async Task<CoreResult> CreateAsync(ThingDef entity)
    {
        var retval = CoreResult.Success;

        try
        {
            await _thingDefsMongoCollection.InsertOneAsync(entity);
            await entity.DispatchEventsAsync();
        }
        catch (Exception e)
        {
            retval = CoreResultFactory.CreateFailedResult(
                new CoreError { Message = e.Message });
        }

        return retval;
    }
}