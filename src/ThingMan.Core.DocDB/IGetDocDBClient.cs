using MongoDB.Driver;

namespace ThingMan.Core.DocDB;

public interface IGetDocDBClient
{
    IMongoClient Get();
}