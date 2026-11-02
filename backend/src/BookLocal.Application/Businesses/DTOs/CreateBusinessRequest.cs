using System.ComponentModel.DataAnnotations;

namespace BookLocal.Application.Businesses.DTOs;

public class CreateBusinessRequest
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;


    [StringLength(500)]
    public string? Description { get; set; }
}