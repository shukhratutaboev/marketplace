using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Domain.Entities.TableModels;

[Table("category")]
public class Category
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string Name { get; set; }

    public long? ParentId { get; set; }

    public bool IsLeafCategory { get; set; }

    [ForeignKey(nameof(ParentId))]
    public Category Parent { get; set; }
    
    public ICollection<Category> SubCategories { get; set; }

    public ICollection<Brand> Brands { get; set; }

    public ICollection<Attribute> Attributes { get; set; }

}