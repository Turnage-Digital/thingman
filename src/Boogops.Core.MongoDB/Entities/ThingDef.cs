using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Boogops.Core.MongoDB.Entities;

public class ThingDef : Core.Domain.Entities.ThingDef
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}