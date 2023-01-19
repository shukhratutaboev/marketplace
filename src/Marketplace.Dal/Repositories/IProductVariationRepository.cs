using Marketplace.Domain.Entities.MongoModels;

namespace Marketplace.Dal.Repositories;

public interface IProductVariationRepository
{
    Task AddAsync(ProductVariation product);
    Task<ProductVariation> GetAsync(string id);
    Task<bool> RemoveAsync(string id);
    Task<IEnumerable<ProductVariation>> GetAllAsync();
    Task<bool> UpdateAsync(ProductVariation product);
}