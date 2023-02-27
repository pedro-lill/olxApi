using System.ComponentModel.DataAnnotations;

namespace olxApi.Dtos;

public class UpdateStateDto
{
    [Required]
    [MaxLength(50)]
    public string? name { get; set; }
}