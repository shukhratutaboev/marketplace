using Marketplace.Domain.Entities.TableModels;

namespace Marketplace.Dal.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public Task<Category> AddAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Category> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Category> UpdateAsync(Category category)
    {
        throw new NotImplementedException();
    }
}