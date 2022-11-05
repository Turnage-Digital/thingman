using MongoDB.Driver;

namespace ThingMan.DocDB;

public interface IGetDocDBCollection
{
    IMongoCollection<T> Get<T>(string collection);
}