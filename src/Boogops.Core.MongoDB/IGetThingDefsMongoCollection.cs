namespace Boogops.Core.MongoDB;

public interface IGetThingDefsMongoCollection<TThingDef>
{
    IMongoCollectionFacade<TThingDef> Get();
}