using Microsoft.Azure.Cosmos;

namespace ThingMan.DocDB;

public interface IGetDatabase
{
    Task<Database> GetAsync();
}