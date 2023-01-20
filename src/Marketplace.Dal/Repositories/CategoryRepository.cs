using Marketplace.Dal.Data;
using Marketplace.Domain.Entities.TableModels;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Dal.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly MarketplaceDbContext _context;

    public CategoryRepository(MarketplaceDbContext context)
    {
        _context = context;
    }
    public async Task<Category> AddAsync(Category category)
    {
        var entity = await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

        return entity.Entity;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetAsync(long id)
    {
        return await _context.Categories.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<Category> RemoveAsync(long id)
    {
        var category = await GetAsync(id);
        var entity = _context.Categories.Remove(category);
        await _context.SaveChangesAsync();

        return entity.Entity;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        var entity = _context.Categories.Update(category);
        await _context.SaveChangesAsync();

        return entity.Entity;
    }

    public async Task<IEnumerable<long>> GetAllChildCategoriesAsync(long id)
    {
        var category = await _context.Categories.Include(c => c.SubCategories).FirstOrDefaultAsync(c => c.Id == id);
        return await GetAllChildCategoriesAsync(category);
    }

    private async Task<IEnumerable<long>> GetAllChildCategoriesAsync(Category category)
    {
        var childCategories = new List<long>();

        if (category == null)
        {
            return childCategories;
        }

        if (category.IsLeafCategory)
        {
            childCategories.Add(category.Id);
            return childCategories;
        }

        foreach (var subCategory in category.SubCategories)
        {
            childCategories.AddRange(await GetAllChildCategoriesAsync(subCategory));
        }

        return childCategories;
    }
}