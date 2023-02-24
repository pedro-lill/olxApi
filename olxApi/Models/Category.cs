using System.ComponentModel.DataAnnotations;
namespace olxApi.Models;

public class Category
{
       // category has a 3 elements _id, name and slug
    [Key]
    public int _id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string name { get; set; }

    [Required]
    [MaxLength(50)]
    public string slug { get; set; }
}
