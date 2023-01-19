using Marketplace.Dal.Data;
using Marketplace.Domain.Entities.TableModels;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Dal.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly MarketplaceDbContext _context;

    public ProductRepository(MarketplaceDbContext context)
    {
        _context = context;
    }
    public async Task<Product> AddAsync(Product product)
    {
        var entity = await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return entity.Entity;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetAsync(long id)
    {
        return await _context.Products.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<Product> RemoveAsync(long id)
    {
        var product = await GetAsync(id);
        var entity = _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return entity.Entity;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        var entity = _context.Products.Update(product);
        await _context.SaveChangesAsync();

        return entity.Entity;
    }
}