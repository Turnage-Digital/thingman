using MongoDB.Driver;

namespace ThingMan.Core.DocDB;

public interface IGetDocDBCollection
{
    IMongoCollection<T> Get<T>(string collection);
}