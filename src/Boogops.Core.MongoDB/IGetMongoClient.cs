using MongoDB.Driver;

namespace Boogops.Core.MongoDB;

public interface IGetMongoClient
{
    IMongoClient Get();
}