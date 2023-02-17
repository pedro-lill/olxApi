using System.ComponentModel.DataAnnotations;

namespace olxApi.Dtos;

public class UpdateUserDto
{
    [Required]
    [StringLength(50, ErrorMessage ="O nome deve ter no máximo 50 caracteres")]
    public string name { get; set; }

    // email validation. check later
    [Required]
    [EmailAddress]
    // [StringLength(50, ErrorMessage ="O email deve ter no máximo 50 caracteres")]
    // [DataType(DataType.EmailAddress)]
    // [Display(Name = "Email")]
    // [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email is not valid")]
    public string email { get; set; }

    [Required]
    [StringLength(50, ErrorMessage ="O nome do estado deve ter no máximo 50 caracteres")]
    public string state { get; set; }

    [Required]
    // password validation. check later
    public string password { get; set; }

    [Required]
    public string token { get; set; }
}