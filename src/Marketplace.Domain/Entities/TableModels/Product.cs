using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Domain.Entities.TableModels;

[Table("products")]
public class Product
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public long CategoryId { get; set; }

    public long BrandId { get; set; }

    [ForeignKey(nameof(BrandId))]
    public Brand Brand { get; set; }
    
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }
    
    
}