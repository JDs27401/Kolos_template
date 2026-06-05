using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public record CreatePCRequest
(
    [MaxLength(50)] string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);