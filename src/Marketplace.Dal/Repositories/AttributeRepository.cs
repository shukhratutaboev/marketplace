using Marketplace.Dal.Data;
using Microsoft.EntityFrameworkCore;
using Attribute = Marketplace.Domain.Entities.TableModels.Attribute;

namespace Marketplace.Dal.Repositories;

public class AttributeRepository : IAttributeRepository
{
    private readonly MarketplaceDbContext _context;

    public AttributeRepository(MarketplaceDbContext context)
    {
        _context = context;
    }
    public async Task<Attribute> AddAsync(Attribute attribute)
    {
        var entity = await _context.Attributes.AddAsync(attribute);
        await _context.SaveChangesAsync();

        return entity.Entity;
    }

    public async Task AddRangeAsync(IEnumerable<Attribute> attributes)
    {
        await _context.Attributes.AddRangeAsync(attributes);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Attribute>> GetAllAsync()
    {
        return await _context.Attributes.ToListAsync();
    }

    public async Task<Attribute> GetAsync(long id)
    {
        return await _context.Attributes.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Attribute>> GetCategoryAttributesAsync(long categoryId)
    {
        return await _context.Attributes.Where(a => a.CategoryId == categoryId).ToListAsync();
    }

    public async Task<Attribute> RemoveAsync(long id)
    {
        var attribute = await GetAsync(id);
        var entity = _context.Remove(attribute);
        await _context.SaveChangesAsync();

        return entity.Entity;
    }

    public async Task<Attribute> UpdateAsync(Attribute attribute)
    {
        var entity = _context.Attributes.Update(attribute);
        await _context.SaveChangesAsync();

        return entity.Entity;
    }
}