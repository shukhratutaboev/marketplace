namespace Marketplace.Api.Models;

public class ProductVariationCraete
{
    public Dictionary<string, string> Attributes { get; set; }

    public long Price { get; set; }

    public int Quantity { get; set; }
}