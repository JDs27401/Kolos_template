using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class ComponentTypes
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(30)]
    public string Abbreviation { get; set; } = string.Empty;
    
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    public IEnumerable<Komponent> Components { get; set; } = [];
}