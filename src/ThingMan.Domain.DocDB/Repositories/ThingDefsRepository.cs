using Microsoft.Azure.Cosmos;
using ThingMan.Core;
using ThingMan.DocDB;
using ThingMan.Domain.Entities;
using ThingMan.Domain.Extensions;
using ThingMan.Domain.Repositories;

namespace ThingMan.Domain.DocDB.Repositories;

public class ThingDefsRepository : IThingDefsRepository<ThingDef>
{
    private readonly IGetThingDefsContainer _thingDefsContainerGetter;

    public ThingDefsRepository(IGetThingDefsContainer thingDefsContainerGetter)
    {
        _thingDefsContainerGetter = thingDefsContainerGetter;
    }

    public async Task<ThingDef?> ReadAsync(string id)
    {
        var thingDefsContainer = await _thingDefsContainerGetter.GetAsync();
        var itemResponse = await thingDefsContainer.ReadItemAsync<ThingDef>(id, new PartitionKey(id));
        var retval = itemResponse.Resource;
        return retval;
    }

    public async Task<CoreResult> CreateAsync(ThingDef entity)
    {
        var retval = CoreResult.Success;

        try
        {
            var thingDefsContainer = await _thingDefsContainerGetter.GetAsync();
            await thingDefsContainer.CreateItemAsync(entity, new PartitionKey(entity.Id));
            await entity.DispatchEventsAsync();
        }
        catch (Exception e)
        {
            retval = CoreResult.CreateFailedResult(
                new CoreError { Message = e.Message });
        }

        return retval;
    }
}