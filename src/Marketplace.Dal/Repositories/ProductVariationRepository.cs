using Marketplace.Domain.Entities.MongoModels;

namespace Marketplace.Dal.Repositories;

public class ProductVariationRepository : IProductVariationRepository
{
    public Task<ProductVariation> AddAsync(ProductVariation product)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductVariation>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProductVariation> GetAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductVariation> RemoveAsync(string product)
    {
        throw new NotImplementedException();
    }

    public Task<ProductVariation> UpdateAsync(ProductVariation product)
    {
        throw new NotImplementedException();
    }
}