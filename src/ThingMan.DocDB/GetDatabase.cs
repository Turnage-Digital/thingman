using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

namespace ThingMan.DocDB;

internal class GetDatabase : IGetDatabase
{
    private readonly CosmosClient _client;
    private readonly string? _databaseName;

    public GetDatabase(IOptions<DocDBOptions> options)
    {
        _client = new CosmosClient(options.Value.Account, options.Value.Key);
        _databaseName = options.Value.DatabaseName;
    }

    public async Task<Database> GetAsync()
    {
        var databaseResponse = await _client.CreateDatabaseIfNotExistsAsync(_databaseName);
        var retval = databaseResponse.Database;
        return retval;
    }
}