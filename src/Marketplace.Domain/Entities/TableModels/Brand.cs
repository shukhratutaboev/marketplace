using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Domain.Entities.TableModels;

[Table("brand")]
public class Brand
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    public string Name { get; set; }

    public string Description { get; set; }

    public ICollection<Category> Categories { get; set; }
    
}