namespace Boogops.Core.MongoDb;

public interface IGetThingDefsMongoCollection<TThingDef>
{
    IMongoCollectionFacade<TThingDef> Get();
}