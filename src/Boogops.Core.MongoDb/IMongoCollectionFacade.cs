using MongoDB.Driver;

namespace Boogops.Core.MongoDb;

public interface IMongoCollectionFacade<T>
{
    Task InsertOneAsync(T document);

    IFindFluentFacade<T> Find(FilterDefinition<T> filterDefinition);
}

public interface IFindFluentFacade<T>
{
    Task<T> SingleAsync();
}