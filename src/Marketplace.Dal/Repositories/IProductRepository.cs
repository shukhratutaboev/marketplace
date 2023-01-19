using Marketplace.Domain.Entities.TableModels;

namespace Marketplace.Dal.Repositories;

public interface IProductRepository
{
    Task<Product> AddAsync(Product product);
    Task<Product> GetAsync(long id);
    Task<Product> RemoveAsync(long id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> UpdateAsync(Product product);
}