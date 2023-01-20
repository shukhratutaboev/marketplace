using Marketplace.Domain.Entities.MongoModels;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Marketplace.Dal.Data;

public class MongoDbContext
{
    public MongoDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
        var database = client.GetDatabase(configuration.GetSection("MongoDbSettings:DatabaseName").Value);

        Products = database.GetCollection<ProductVariation>(configuration.GetSection("MongoDbSettings:ProductsCollectionName").Value);
    }
    public IMongoCollection<ProductVariation> Products { get; }
}