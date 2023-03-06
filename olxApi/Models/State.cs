using System.ComponentModel.DataAnnotations;
namespace olxApi.Models;

public class State
{

    [Key]
    [Required]
    public int _id { get; set; }

    [Required]
    [MaxLength(50)]
    public string? name { get; set; }
}
