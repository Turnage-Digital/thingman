using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

namespace ThingMan.DocDB;

internal class GetDatabase : IGetDatabase
{
    private readonly Database _database;

    public GetDatabase(IOptions<DocDBOptions> options)
    {
        var client = new CosmosClient(options.Value.Account, options.Value.Key);
        var response = client.CreateDatabaseIfNotExistsAsync(options.Value.Database).Result;
        
        _database = response.Database;
    }

    public Database Get() => _database;
}