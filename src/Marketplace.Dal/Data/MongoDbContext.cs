using Marketplace.Domain.Entities.MongoModels;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Marketplace.Dal.Data;

public class MongoDbContext
{
    public MongoDbContext(IConfiguration configuration)
    {
        var client = new MongoClient("");
        var database = client.GetDatabase("");

        Products = database.GetCollection<ProductVariation>("");
    }
    public IMongoCollection<ProductVariation> Products { get; }
}