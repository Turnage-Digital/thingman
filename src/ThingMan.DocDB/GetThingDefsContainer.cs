using Microsoft.Azure.Cosmos;

namespace ThingMan.DocDB;

public class GetThingDefsContainer : IGetThingDefsContainer
{
    private readonly IGetDatabase _getDatabase;

    public GetThingDefsContainer(IGetDatabase getDatabase)
    {
        _getDatabase = getDatabase;
    }

    public async Task<Container> GetAsync()
    {
        var database = _getDatabase.Get();
        var retval = await database
            .CreateContainerIfNotExistsAsync("ThingDefs", "/UserId");
        return retval;
    }
}