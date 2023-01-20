namespace Marketplace.Api.Models;

public class AttributeCreate
{
    public string Name { get; set; }

    public bool IsFiltered { get; set; }

    public bool IsHaveValues { get; set; }

    public List<string> Values { get; set; }
}