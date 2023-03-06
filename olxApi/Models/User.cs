
using System.ComponentModel.DataAnnotations;
namespace olxApi.Models;

public class User
{
    [Key]
    [Required]
    public int _id { get; set; }

    [Required]
    [StringLength(50, ErrorMessage ="O nome deve ter no máximo 100 caracteres")]
    public string? name { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    //[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email is not valid")]
    public string? email { get; set; }
    [Required]
    public string? password { get; set; }

    public string? token { get; set; }

    public int state_id { get; set; }

    public State state { get; set;}
}
