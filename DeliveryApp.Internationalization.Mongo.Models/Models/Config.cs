using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace DeliveryApp.Internationalization.Mongo.Models.Models;

public class Config
{
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; }

    public string PageName { get; set; }
    public Dictionary<string, string> DynamicConfigs { get; set; }
}