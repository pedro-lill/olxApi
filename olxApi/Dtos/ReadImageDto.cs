using System.ComponentModel.DataAnnotations;
namespace olxApi.Dtos;

public class ReadImageDto
{
    [Required]
    public string? url { get; set; }

    [Required]
    public bool isDefault { get; set; }

}