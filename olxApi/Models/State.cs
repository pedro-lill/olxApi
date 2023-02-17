using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace olxApi.Models;

public class State
{
    // state has a 2 elements _id, name
    [Key]
    [Required]
    [MaxLength(50)]
    public string _id { get; set; }

    [Required]
    [MaxLength(50)]
    public string name { get; set; }
}
