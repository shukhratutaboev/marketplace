using Attribute = Marketplace.Domain.Entities.TableModels.Attribute;

namespace Marketplace.Dal.Repositories;

public interface IAttributeRepository
{
    Task<Attribute> AddAsync(Attribute attribute);
    Task AddRangeAsync(IEnumerable<Attribute> attributes);
    Task<IEnumerable<Attribute>> GetCategoryAttributesAsync(long categoryId);
    Task<Attribute> GetAsync(long id);
    Task<Attribute> RemoveAsync(long id);
    Task<IEnumerable<Attribute>> GetAllAsync();
    Task<Attribute> UpdateAsync(Attribute attribute);
}