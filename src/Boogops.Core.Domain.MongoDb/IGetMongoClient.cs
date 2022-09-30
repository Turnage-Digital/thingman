using MongoDB.Driver;

namespace Boogops.Core.Domain.MongoDb;

public interface IGetMongoClient
{
    IMongoClient Get();
}