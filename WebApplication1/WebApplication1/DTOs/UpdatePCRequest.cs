using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public record UpdatePCRequest
(
    [MaxLength(50)] string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);