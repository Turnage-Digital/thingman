using MongoDB.Driver;

namespace Boogops.Core.Domain.DocDB;

public interface IGetDocDBClient
{
    IMongoClient Get();
}