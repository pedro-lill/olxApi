using System.ComponentModel.DataAnnotations;

namespace olxApi.Dtos;

/// <summary>
/// The state's data transfer object
/// </summary>
public class CreateStateDto
{   
    /// <summary>
    /// The state's name
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string? name { get; set; }

}

