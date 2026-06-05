using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

[PrimaryKey(nameof(PcId), nameof(ComponentCode))]
public class PcComponents
{
    public int PcId { get; set; }
    
    [Column(TypeName = "char(10)")]
    public string ComponentCode { get; set; }
    public int Amount { get; set; }

    [ForeignKey(nameof(PcId))]
    public PCs PC { get; set; } = null!;
    
    [ForeignKey(nameof(ComponentCode))]
    public Komponent Komponent { get; set; } = null!;
}