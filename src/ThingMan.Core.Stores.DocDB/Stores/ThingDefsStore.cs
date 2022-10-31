using MongoDB.Driver;
using ThingMan.Core.DocDB;
using ThingMan.Core.Stores.Dtos;
using ThingMan.Core.Stores.Stores;

namespace ThingMan.Core.Stores.DocDB.Stores;

public class ThingDefsStore : IThingDefsStore
{
    // Probably won't need a projection from the original collection
    private const string COLLECTION = "ThingDef";
    
    private readonly IMongoCollection<ThingDefDto> _thingDefsMongoCollection;
    
    public ThingDefsStore(IGetDocDBCollection getDocDbCollection)
    {
        _thingDefsMongoCollection = getDocDbCollection.Get<ThingDefDto>(COLLECTION);
    }

    public async Task<ThingDefDto> GetById(string id)
    {
        var filter = Builders<ThingDefDto>.Filter.Eq(x => x.Id, id);
        var retval = await _thingDefsMongoCollection.Find(filter)
            .SingleAsync();
        return retval;
    }
}