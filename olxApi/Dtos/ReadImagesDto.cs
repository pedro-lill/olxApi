using System.ComponentModel.DataAnnotations;
namespace olxApi.Dtos;

public class ReadImagesDto
{
    [Required]
    public string? url { get; set; }

    [Required]
    public bool isDefault { get; set; }
}