using Marketplace.Domain.Entities.TableModels;

namespace Marketplace.Dal.Repositories;

public interface IBrandRepository
{
    Task<Brand> AddAsync(Brand brand);
    Task<Brand> GetAsync(long brand);
    Task<Brand> RemoveAsync(long id);
    Task<IEnumerable<Brand>> GetAllAsync();
    Task<Brand> UpdateAsync(Brand brand);
}