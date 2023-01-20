using Marketplace.Domain.Entities.TableModels;

namespace Marketplace.Dal.Repositories;

public interface ICategoryRepository
{
    Task<Category> AddAsync(Category category);
    Task<Category> GetAsync(long id);
    Task<Category> RemoveAsync(long id);
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category> UpdateAsync(Category category);
    Task<IEnumerable<long>> GetAllChildCategoriesAsync(long id);
}