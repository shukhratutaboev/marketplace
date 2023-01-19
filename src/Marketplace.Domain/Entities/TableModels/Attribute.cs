using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Domain.Entities.TableModels;

[Table("attribute")]
public class Attribute
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    public string Name { get; set; }

    public bool IsFiltered { get; set; }

    public bool IsHaveValues { get; set; }

    public List<string> Values { get; set; }
}