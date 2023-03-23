using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using olxApi.Models;

namespace olxApi.Dtos;

public class CreateAnuncioDto
{
    [Required]
    public string ?cat { get; set; }

    [NotMapped]
    public Category ?category { get; set; }

    [Required]
    public string? title { get; set; }

    public DateTime dateCreated { get; set; } 

    public double price { get; set; }

    [Required]
    public bool priceNeg { get; set; }

    [Required]
    public string? desc { get; set; }

    public string ?token { get; set; }

    public List<IFormFile> ?img { get; set; }
}