using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class ComponentManufacturers
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Abbreviation { get; set; } = string.Empty;

    [MaxLength(300)] public string FullName { get; set; } = string.Empty;
    public DateTime FoundationDate { get; set; }
    
    public IEnumerable<Komponent> Components { get; set; } = [];
}