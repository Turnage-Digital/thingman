using MongoDB.Driver;

namespace Boogops.Core.Domain.DocDB;

public interface IGetDocDBCollection
{
    IMongoCollection<T> Get<T>(string collection);
}