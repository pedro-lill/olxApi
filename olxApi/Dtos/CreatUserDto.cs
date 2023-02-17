using System.ComponentModel.DataAnnotations;

namespace olxApi.Dtos;

public class CreateUserDto
{   

    [Required]
    public string name { get; set; }

    [Required]
    public string email { get; set; }

    [Required]
    public string state { get; set; }

    [Required]
    public string password { get; set; }

    [Required]
    public string token { get; set; }
 
}

