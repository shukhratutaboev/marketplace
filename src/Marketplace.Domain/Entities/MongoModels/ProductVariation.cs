using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Marketplace.Domain.Entities.MongoModels;

public class ProductVariation
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public long PoductId { get; set; }

    public long CategoryId { get; set; }

    public Dictionary<string, string> Attributes { get; set; }

    public long Price { get; set; }

    public int Quantity { get; set; }
}