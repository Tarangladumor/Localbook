
using System.ComponentModel.DataAnnotations;

namespace BookLocal.Application.Businesses.DTOs;

public class UpdateBusinessRequest
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }
}