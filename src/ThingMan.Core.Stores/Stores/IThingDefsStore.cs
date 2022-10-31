using ThingMan.Core.Stores.Dtos;

namespace ThingMan.Core.Stores.Stores;

public interface IThingDefsStore
{
    Task<ThingDefDto> GetById(string id);
}