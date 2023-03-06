using System.ComponentModel.DataAnnotations;

namespace olxApi.Dtos;

/// <summary>
/// The user's data transfer object
/// </summary>
public class LoginUserDto
{   

    [Required]
    public string? email { get; set; }

 
    [Required]
    public string? password { get; set; }


}

