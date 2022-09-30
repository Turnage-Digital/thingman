using MongoDB.Driver;

namespace Boogops.Core.Domain.MongoDb;

public interface IGetThingDefsMongoCollection<TThingDef>
{
    IMongoCollection<TThingDef> Get();
}