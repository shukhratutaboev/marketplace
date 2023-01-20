namespace Marketplace.Api.Models;

public class ProductCreate
{
    public string Name { get; set; }
    
    public long CategoryId { get; set; }

    public long BrandId { get; set; }
}