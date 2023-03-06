using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace olxApi.Dtos;
/// <summary>
/// The Images's data transfer object
/// </summary>
public class CreateImagesDto
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