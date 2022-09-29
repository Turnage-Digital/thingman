using MongoDB.Driver;

namespace Boogops.Core.MongoDb;

public interface IGetThingDefsMongoCollection<TThingDef>
{
    IMongoCollection<TThingDef> Get();
}