using Marketplace.Dal.Data;
using Marketplace.Domain.Entities.TableModels;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Dal.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly MarketplaceDbContext _context;

    public BrandRepository(MarketplaceDbContext context)
    {
        _context = context;
    }
    public async Task<Brand> AddAsync(Brand brand)
    {
        var entity = await _context.Brands.AddAsync(brand);
        await _context.SaveChangesAsync();

        return entity.Entity;
    }

    public async Task<IEnumerable<Brand>> GetAllAsync()
    {
        return await _context.Brands.ToListAsync();
    }

    public async Task<Brand> GetAsync(long id)
    {
        return await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<Brand> RemoveAsync(long id)
    {
        var brand = await GetAsync(id);
        var entity = _context.Remove(brand);
        await _context.SaveChangesAsync();

        return entity.Entity;
    }

    public async Task<Brand> UpdateAsync(Brand brand)
    {
        var entity = _context.Brands.Update(brand);
        await _context.SaveChangesAsync();

        return entity.Entity;
    }
}