using Attribute = Marketplace.Domain.Entities.TableModels.Attribute;

namespace Marketplace.Dal.Repositories;

public class AttributeRepository : IAttributeRepository
{
    public Task<Attribute> AddAsync(Attribute attribute)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Attribute>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Attribute> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Attribute> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Attribute> UpdateAsync(Attribute attribute)
    {
        throw new NotImplementedException();
    }
}