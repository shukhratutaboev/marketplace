using Marketplace.Domain.Entities.TableModels;

namespace Marketplace.Dal.Repositories;

public class BrandRepository : IBrandRepository
{
    public Task<Brand> AddAsync(Brand brand)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Brand>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Brand> GetAsync(long brand)
    {
        throw new NotImplementedException();
    }

    public Task<Brand> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Brand> UpdateAsync(Brand brand)
    {
        throw new NotImplementedException();
    }
}