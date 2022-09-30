using Boogops.Core.Store.Contracts.Dtos;

namespace Boogops.Core.Store.Stores;

public interface IThingDefsStore
{
    Task<ThingDefDto> GetById(string id);
}