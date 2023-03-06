using System.ComponentModel.DataAnnotations;

namespace olxApi.Dtos;

/// <summary>
/// The user's data transfer object
/// </summary>
public class CreateUserDto
{   

    /// <summary>
    /// The user's name
    /// </summary>
    [Required]
    public string? name { get; set; }

    /// <summary>
    /// The user's email
    /// </summary>
    [Required]
    [EmailAddress]
    public string? email { get; set; }

    /// <summary>
    /// The user's state
    /// </summary>
    [Required]
    public int state_id { get; set; }

    /// <summary>
    /// The user's password
    /// </summary>
    [Required]
    public string? password { get; set; }

    /// <summary>
    /// The user's token
    /// </summary>
    [Required]
    public string? token { get; set; }
 
}

