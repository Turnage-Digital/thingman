using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Boogops.Core.Domain.MongoDb;

internal class GetMongoClient : IGetMongoClient
{
    private readonly string _connectionString;

    public GetMongoClient(IOptions<MongoDbOptions> options)
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