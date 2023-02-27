using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
namespace olxApi.Dtos;

/// <summary>
/// Dto to create a new Anuncio
/// </summary>
public class UpdateAnuncioDto
{
    [ForeignKey("User")]
    [Required]
    [Display(Name = "Id do usuário")]
    public string user_id { get; set; }
    
    [ForeignKey("State")]
    [Required]
    [StringLength(50, ErrorMessage ="O nome do estado deve ter no máximo 50 caracteres")]
    public string state_id { get; set; }

    [ForeignKey("Category")]
    [Required]
    [StringLength(50, ErrorMessage ="O nome da categoria deve ter no máximo 50 caracteres")]
    public string category_id { get; set; }

    [Required]
    public DateTime dateCreated { get; set; } 

    [Required]
    [StringLength(50, ErrorMessage ="O nome do titulo deve ter no máximo 50 caracteres")]
    public string title { get; set; }

    [Required]
    public double price { get; set; }

    [Required]
    public bool priceNeg { get; set; }

    [Required]
    public string desc { get; set; }

    [Required]
    public int views { get; set; }

    [Required]
    public string status { get; set; }
    
}