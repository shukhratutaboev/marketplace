using Marketplace.Domain.Entities.TableModels;

namespace Marketplace.Dal.Repositories;

public class ProductRepository : IProductRepository
{
    public Task<Product> AddAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Product> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Product> UpdateAsync(Product product)
    {
        throw new NotImplementedException();
    }
}