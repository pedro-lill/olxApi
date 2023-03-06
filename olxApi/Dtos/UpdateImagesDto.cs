using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
namespace olxApi.Dtos;

public class UpdateImagesDto
{
    [Key]
    [Required]
    public int _id { get; set; }
    
    [Required]
    public string? url { get; set; }

    [Required]
    public bool isDefault { get; set; }

    [Required]
    [ForeignKey("Anuncio")]
    public string? ad_id { get; set; }
}