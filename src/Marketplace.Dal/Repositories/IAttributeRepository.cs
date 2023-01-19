using Attribute = Marketplace.Domain.Entities.TableModels.Attribute;

namespace Marketplace.Dal.Repositories;

public interface IAttributeRepository
{
    Task<Attribute> AddAsync(Attribute attribute);
    Task<Attribute> GetAsync(long id);
    Task<Attribute> RemoveAsync(long id);
    Task<IEnumerable<Attribute>> GetAllAsync();
    Task<Attribute> UpdateAsync(Attribute attribute);
}