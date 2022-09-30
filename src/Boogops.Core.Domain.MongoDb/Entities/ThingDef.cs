using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Boogops.Core.Domain.MongoDb.Entities;

public class ThingDef : Domain.Entities.ThingDef
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}