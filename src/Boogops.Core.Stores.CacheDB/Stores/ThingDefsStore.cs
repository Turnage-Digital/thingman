using Boogops.Core.Stores.Dtos;
using Boogops.Core.Stores.Stores;

namespace Boogops.Core.Stores.CacheDB.Stores;

public class ThingDefsStore : IThingDefsStore
{
    // private const string COLLECTION = "ThingDefDtos";
    //
    // private readonly IMongoCollection<ThingDefDto> _thingDefsMongoCollection;
    //
    // public ThingDefsStore(IGetDocDBCollection getDocDbCollection)
    // {
    //     _thingDefsMongoCollection = getDocDbCollection.Get<ThingDefDto>(COLLECTION);
    // }

    public Task<ThingDefDto> GetById(string id)
    {
        // var filter = Builders<ThingDefDto>.Filter.Eq(x => x.Id, id);
        // var retval = await _thingDefsMongoCollection.Find(filter)
        //     .SingleAsync();
        // return retval;

        throw new NotImplementedException();
    }
}