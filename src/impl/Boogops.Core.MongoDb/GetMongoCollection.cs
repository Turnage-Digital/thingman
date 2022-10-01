using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Boogops.Core.Domain.MongoDb;

internal class GetMongoCollection : IGetMongoCollection
{
    private readonly string _database;

    private readonly IMongoClient _mongoClient;

    public GetMongoCollection(IOptions<MongoDbOptions> options, IGetMongoClient mongoClientGetter)
    {
        _database = options.Value.Database ??
                    throw new ArgumentException("StoreOptions.Database is null");
        _mongoClient = mongoClientGetter.Get();
    }

    public IMongoCollection<T> Get<T>(string collection)
    {
        var database = _mongoClient.GetDatabase(_database);
        var retval = database.GetCollection<T>(collection);
        return retval;
    }
}