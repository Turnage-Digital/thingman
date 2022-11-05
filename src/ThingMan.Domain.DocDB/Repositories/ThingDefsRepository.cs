using Microsoft.Azure.Cosmos;
using ThingMan.Core;
using ThingMan.DocDB;
using ThingMan.Domain.Entities;
using ThingMan.Domain.Repositories;

namespace ThingMan.Domain.DocDB.Repositories;

public class ThingDefsRepository : IThingDefsRepository<ThingDef>
{
    private readonly Container _thingDefsContainer;

    public ThingDefsRepository(IGetThingDefsContainer thingDefsContainerGetter)
    {
        _thingDefsContainer = thingDefsContainerGetter.GetAsync().Result;
    }

    public Task<ThingDef?> ReadAsync(string id)
    {
        throw new NotImplementedException();
        // var filter = Builders<ThingDef>.Filter.Eq(x => x.Id, id);
        // var retval = await _thingDefsMongoCollection.Find(filter)
        //     .SingleAsync();
        // return retval;
    }

    public Task<CoreResult> CreateAsync(ThingDef entity)
    {
        throw new NotImplementedException();
        // var retval = CoreResult.Success;
        //
        // try
        // {
        //     await _thingDefsMongoCollection.InsertOneAsync(entity);
        //     await entity.DispatchEventsAsync();
        // }
        // catch (Exception e)
        // {
        //     retval = CoreResultFactory.CreateFailedResult(
        //         new CoreError { Message = e.Message });
        // }
        //
        // return retval;
    }
}