using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("Components")]
public class Komponent
{
    [Key, Column(TypeName = "char(10)")]
    public string Code { get; set; } = null!;
    
    [MaxLength(300)]
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = null!;
    
    [ForeignKey(nameof(ComponentManufacturersId))]
    public int ComponentManufacturersId { get; set; }
    
    [ForeignKey(nameof(ComponentTypesId))]
    public int ComponentTypesId { get; set; }
    
    public ComponentManufacturers ComponentManufacturer { get; set; } = null!;
    public ComponentTypes ComponentType { get; set; } = null!;
}