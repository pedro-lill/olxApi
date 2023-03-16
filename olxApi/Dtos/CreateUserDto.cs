using System.ComponentModel.DataAnnotations;
using olxApi.Data;

namespace olxApi.Dtos;
public class CreateUserDto
{   
    [Required]
    public string? name { get; set; }

    [Required]
    [EmailAddress]
    public string? email { get; set; }

    [Required]
    public string? password { get; set; }

    public string? token { get; set; }

    [Required]
    public int? state_id { get; set; }
}