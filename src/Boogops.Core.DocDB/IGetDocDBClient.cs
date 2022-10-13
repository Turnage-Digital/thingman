using MongoDB.Driver;

namespace Boogops.Core.DocDB;

public interface IGetDocDBClient
{
    IMongoClient Get();
}