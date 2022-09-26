using MongoDB.Driver;

namespace Boogops.Core.MongoDb;

public interface IGetMongoClient
{
    IMongoClient Get();
}