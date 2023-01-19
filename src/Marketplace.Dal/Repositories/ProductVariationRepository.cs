using Marketplace.Dal.Data;
using Marketplace.Domain.Entities.MongoModels;
using MongoDB.Driver;

namespace Marketplace.Dal.Repositories;

public class ProductVariationRepository : IProductVariationRepository
{
    private readonly MongoDbContext _context;

    public ProductVariationRepository(MongoDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(ProductVariation product)
    {
        await _context.Products.InsertOneAsync(product);
    }

    public async Task<IEnumerable<ProductVariation>> GetAllAsync()
    {
        var products = await _context.Products.FindAsync(p => true);

        return await products.ToListAsync();
    }

    public async Task<ProductVariation> GetAsync(string id)
    {
        var product = await _context.Products.FindAsync(p => p.Id == id);

        return await product.FirstOrDefaultAsync();
    }

    public async Task<bool> RemoveAsync(string id)  
    {
        var result = await _context.Products.DeleteOneAsync(p => p.Id == id);

        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    public async Task<bool> UpdateAsync(ProductVariation product)
    {
        var result = await _context.Products.ReplaceOneAsync(p => p.Id == product.Id, product);

        return result.IsAcknowledged && result.ModifiedCount > 0;
    }
}