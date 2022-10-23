using Boogops.Core.Stores.Dtos;

namespace Boogops.Core.Stores.Stores;

public interface IThingDefsStore
{
    Task<ThingDefDto> GetById(string id);
}