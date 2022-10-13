using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Boogops.Core.DocDB;

internal class GetDocDBCollection : IGetDocDBCollection
{
    private readonly string _database;

    private readonly IMongoClient _mongoClient;

    public GetDocDBCollection(IOptions<DocDBOptions> options, IGetDocDBClient docDbClientGetter)
    {
        _database = options.Value.Database ??
                    throw new ArgumentException("StoreOptions.Database is null");
        _mongoClient = docDbClientGetter.Get();
    }

    public IMongoCollection<T> Get<T>(string collection)
    {
        var database = _mongoClient.GetDatabase(_database);
        var retval = database.GetCollection<T>(collection);
        return retval;
    }
}