using Boogops.Core.Store.Contracts.Dtos;
using Boogops.Core.Store.Stores;

namespace Boogops.Core.Store.DocDB.Stores;

public class ThingDefsStore : IThingDefsStore
{
    public async Task<ThingDefDto> GetById(string id)
    {
        throw new NotImplementedException();
    }
}