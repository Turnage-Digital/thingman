using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

namespace ThingMan.DocDB;

public class GetThingDefsContainer : IGetThingDefsContainer
{
    private readonly IGetDatabase _getDatabase;
    private readonly string? _thingDefsContainerName;
    private readonly string? _thingDefsPartitionKey;

    public GetThingDefsContainer(IGetDatabase getDatabase, IOptions<DocDBOptions> options)
    {
        _getDatabase = getDatabase;
        _thingDefsContainerName = options.Value.ThingDefsContainerName;
        _thingDefsPartitionKey = options.Value.ThingDefsPartitionKey;
    }

    public async Task<Container> GetAsync()
    {
        var database = await _getDatabase.GetAsync();
        var retval = await database
            .CreateContainerIfNotExistsAsync(_thingDefsContainerName, _thingDefsPartitionKey);
        return retval;
    }
}