using Microsoft.Azure.Cosmos;

namespace ThingMan.DocDB;

public interface IGetThingDefsContainer
{
    Task<Container> GetAsync();
}