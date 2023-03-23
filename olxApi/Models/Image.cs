using System.ComponentModel.DataAnnotations;
namespace olxApi.Models;

public class Image
{
    [Key]
    [Required]
    public int _id { get; set; }
    
    [Required]
    public string? url { get; set; }

    [Required]
    public bool isDefault { get; set; }

    [Required]
    public int anuncio_id { get; set; }
    
}
