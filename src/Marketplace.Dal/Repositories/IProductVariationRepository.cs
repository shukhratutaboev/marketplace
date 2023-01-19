using Marketplace.Domain.Entities.MongoModels;

namespace Marketplace.Dal.Repositories;

public interface IProductVariationRepository
{
    Task<ProductVariation> AddAsync(ProductVariation product);
    Task<ProductVariation> GetAsync(string id);
    Task<ProductVariation> RemoveAsync(string product);
    Task<IEnumerable<ProductVariation>> GetAllAsync();
    Task<ProductVariation> UpdateAsync(ProductVariation product);
}