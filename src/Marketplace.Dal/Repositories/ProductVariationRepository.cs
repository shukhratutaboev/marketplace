using Marketplace.Dal.Data;
using Marketplace.Domain.Entities.MongoModels;
using MongoDB.Driver;

namespace Marketplace.Dal.Repositories;

public class ProductVariationRepository : IProductVariationRepository
{
    private readonly MongoDbContext _context;
    private readonly ICategoryRepository _categoryRepository;

    public ProductVariationRepository(MongoDbContext context, ICategoryRepository categoryRepository)
    {
        _context = context;
        _categoryRepository = categoryRepository;
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

    public async Task<IEnumerable<ProductVariation>> GetProductsAsync(ProductQuery query)
    {
        var filter = Builders<ProductVariation>.Filter.Empty;
        if (query.CategoryId.HasValue)
        {
            var categories = await _categoryRepository.GetAllChildCategoriesAsync(query.CategoryId.Value);
            filter &= Builders<ProductVariation>.Filter.In(p => p.CategoryId, categories);
        }

        // if (query.BrandId.HasValue)
        // {
        //     filter &= Builders<ProductVariation>.Filter.Eq(p => p.BrandId, query.BrandId.Value);
        // }

        if (query.PriceFrom.HasValue)
        {
            filter &= Builders<ProductVariation>.Filter.Gte(p => p.Price, query.PriceFrom.Value);
        }

        if (query.PriceTo.HasValue)
        {
            filter &= Builders<ProductVariation>.Filter.Lte(p => p.Price, query.PriceTo.Value);
        }

        if (query.QuantityFrom.HasValue)
        {
            filter &= Builders<ProductVariation>.Filter.Gte(p => p.Quantity, query.QuantityFrom.Value);
        }

        if (query.QuantityTo.HasValue)
        {
            filter &= Builders<ProductVariation>.Filter.Lte(p => p.Quantity, query.QuantityTo.Value);
        }

        

        if (query.Attributes != null)
        {
            Dictionary<string, string[]> attributes = new Dictionary<string, string[]>();

            string[] keyValuePairs = query.Attributes.Split(",");
            foreach (string keyValuePair in keyValuePairs)
            {
                string[] parts = keyValuePair.Split("=");
                string key = parts[0];
                string[] values = parts[1].Split("%");
                attributes.Add(key, values);
            }
            foreach (var attribute in attributes)
            {
                filter &= Builders<ProductVariation>.Filter.In(p => p.Attributes[attribute.Key], attribute.Value);
            }
        }

        var products = await _context.Products.FindAsync(filter);

        return await products.ToListAsync();
    }
}

public class ProductQuery
{
    public long? CategoryId { get; set; }
    
    public long? BrandId { get; set; }
    
    public long? PriceFrom { get; set; }
    
    public long? PriceTo { get; set; }
    
    public int? QuantityFrom { get; set; }
    
    public int? QuantityTo { get; set; }
    
    public string Attributes { get; set; }
}