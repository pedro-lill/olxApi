using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace olxApi.Dtos;
/// <summary>
/// The category's data transfer object
/// </summary>
public class CreateCategoryDto
{    
    [Required]
    [MaxLength(50)]
    public string? name { get; set; }

    [Required]
    [MaxLength(50)]
    public string? slug { get; set; }
}