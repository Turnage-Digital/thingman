using MongoDB.Driver;

namespace ThingMan.DocDB;

public interface IGetDocDBClient
{
    IMongoClient Get();
}