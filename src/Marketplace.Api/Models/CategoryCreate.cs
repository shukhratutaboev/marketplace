namespace Marketplace.Api.Models;

public class CategoryCreate
{
    public string Name { get; set; }

    public long? ParentId { get; set; }

    public bool IsLeafCategory { get; set; }
}