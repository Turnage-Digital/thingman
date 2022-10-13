using MongoDB.Driver;

namespace Boogops.Core.DocDB;

public interface IGetDocDBCollection
{
    IMongoCollection<T> Get<T>(string collection);
}