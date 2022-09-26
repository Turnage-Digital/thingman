using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Boogops.Core.MongoDb;

internal class GetThingDefsMongoCollection<TThingDef> : IGetThingDefsMongoCollection<TThingDef>
{
    private const string COLLECTION = "ThingDefs";
    private readonly string _database;

    private readonly IMongoClient _mongoClient;

    public GetThingDefsMongoCollection(
        IOptions<MongoDbOptions> options,
        IGetMongoClient mongoClientGetter
    )
    {
        _database = options.Value.Database ??
                    throw new ArgumentException("StoreOptions.Database is null");
        _mongoClient = mongoClientGetter.Get();
    }

    public IMongoCollectionFacade<TThingDef> Get()
    {
        var database = _mongoClient.GetDatabase(_database);
        var mongoCollection = database.GetCollection<TThingDef>(COLLECTION);
        var retval = new MongoCollectionFacade<TThingDef>(mongoCollection);
        return retval;
    }
}