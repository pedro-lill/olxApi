using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace olxApi.Models;


public class Category
{
       // category has a 3 elements _id, name and slug
    [Key]
    [Required]
    public int _id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string? name { get; set; }

    [Required]
    [MaxLength(50)]
    public string? slug { get; set; }

    [NotMapped]
    public string? img => $"http://localhost:5150/Assets/Media/{slug}.png";
}