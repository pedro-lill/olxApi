using System.ComponentModel.DataAnnotations;

namespace olxApi.Dtos;

public class UpdateStateDto
{
   [Required]
    [MaxLength(50)]
    public string _id { get; set; }

    [Required]
    [MaxLength(50)]
    public string name { get; set; }
}