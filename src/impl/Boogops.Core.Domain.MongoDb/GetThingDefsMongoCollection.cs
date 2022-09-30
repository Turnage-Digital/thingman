using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Boogops.Core.Domain.MongoDb;

internal class GetThingDefsMongoCollection<TThingDef> : IGetThingDefsMongoCollection<TThingDef>
{
    private const string COLLECTION = "ThingDefs";
    private readonly string _database;

    private readonly IMongoClient _mongoClient;

    public GetThingDefsMongoCollection(IOptions<MongoDbOptions> options, IGetMongoClient mongoClientGetter)
    {
        _database = options.Value.Database ??
                    throw new ArgumentException("StoreOptions.Database is null");
        _mongoClient = mongoClientGetter.Get();
    }

    public IMongoCollection<TThingDef> Get()
    {
        var database = _mongoClient.GetDatabase(_database);
        var retval = database.GetCollection<TThingDef>(COLLECTION);
        return retval;
    }
}