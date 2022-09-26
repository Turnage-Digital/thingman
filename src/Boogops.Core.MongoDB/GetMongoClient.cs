using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Boogops.Core.MongoDB;

internal class GetMongoClient : IGetMongoClient
{
    private readonly string _connectionString;

    public GetMongoClient(IOptions<StoreOptions> options)
    {
        _connectionString = options.Value.ConnectionString;
    }

    public IMongoClient Get()
    {
        var retval = new MongoClient(_connectionString);
        return retval;
    }
}