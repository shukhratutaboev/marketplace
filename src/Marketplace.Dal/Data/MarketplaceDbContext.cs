using Marketplace.Domain.Entities.TableModels;
using Microsoft.EntityFrameworkCore;
using Attribute = Marketplace.Domain.Entities.TableModels.Attribute;

namespace Marketplace.Dal.Data;

public class MarketplaceDbContext : DbContext
{
    public DbSet<Attribute> Attributes { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    
    public MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options) : base(options) { }
}