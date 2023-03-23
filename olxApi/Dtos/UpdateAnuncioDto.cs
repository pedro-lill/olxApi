using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using olxApi.Models;

namespace olxApi.Dtos;

/// <summary>
/// Dto to create a new Anuncio
/// </summary>
public class UpdateAnuncioDto
{
   
    public string user_id { get; set; }
    

    public string ?cat { get; set; }

    [Required]
    public string? title { get; set; }

    public DateTime dateCreated { get; set; } 

    public double price { get; set; }

    [Required]
    public bool priceNeg { get; set; }

    [Required]
    public string? desc { get; set; }

    public string ?token { get; set; }

    
    [NotMapped]
    public Category ?category { get; set; }
    public List<IFormFile> ?img { get; set; }
    
}