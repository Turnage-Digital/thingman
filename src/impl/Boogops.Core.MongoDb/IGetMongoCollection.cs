using MongoDB.Driver;

namespace Boogops.Core.Domain.MongoDb;

public interface IGetMongoCollection
{
    IMongoCollection<T> Get<T>(string collection);
}