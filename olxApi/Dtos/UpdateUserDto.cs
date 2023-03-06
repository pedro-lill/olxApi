using System.ComponentModel.DataAnnotations;

namespace olxApi.Dtos;

public class UpdateUserDto
{
    [Required]
    [StringLength(50, ErrorMessage ="O nome deve ter no máximo 50 caracteres")]
    public string? name { get; set; }

    // email validation. check later
    [Required]
    [EmailAddress]
    public string? email { get; set; }

    [Required]
    [StringLength(50, ErrorMessage ="O nome do estado deve ter no máximo 50 caracteres")]
    public int state_id { get; set; }

    [Required]
    // password validation. check later
    public string? password { get; set; }

    [Required]
    public string token { get; set; }
}