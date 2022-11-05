using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ThingMan.DocDB;

internal class GetDocDBClient : IGetDocDBClient
{
    private readonly string _connectionString;

    public GetDocDBClient(IOptions<DocDBOptions> options)
    {
        _connectionString = options.Value.ConnectionString ??
                            throw new ArgumentException("StoreOptions.ConnectionString is null");
    }

    public IMongoClient Get()
    {
        var retval = new MongoClient(_connectionString);
        return retval;
    }
}