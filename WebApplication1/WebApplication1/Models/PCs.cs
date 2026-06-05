using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class PCs
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    
    [Column(TypeName = "float(5,2)")]
    public float Weight { get; set; }
    public int Warranty { get; set; }
    
    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }

    public IEnumerable<PcComponents> PcComponents { get; set; } = [];
}