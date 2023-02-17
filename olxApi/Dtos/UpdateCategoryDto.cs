using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
namespace olxApi.Dtos;

public class UpdateCategoryDto
{
    [Key]
    public int _id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string name { get; set; }

    [Required]
    [MaxLength(50)]
    public string slug { get; set; }
}