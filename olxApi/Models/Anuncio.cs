using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace olxApi.Models;

public class Anuncio
{
    [Key]
    [Required]
    public int _id { get; set; }

    [Required]
    [ForeignKey("idUser")]
    // [StringLength(24, ErrorMessage ="O id do usuário deve ter no máximo 24 caracteres")]
    // [RegularExpression(@"^[a-fA-F0-9]{24}$", ErrorMessage ="O id do usuário deve ser um ObjectId válido")]
    // [Display(Name = "Id do usuário")]
    public string idUser { get; set; }

    [Required]
    [StringLength(50, ErrorMessage ="O nome do estado deve ter no máximo 50 caracteres")]
    public string state { get; set; }

    [Required]
    [StringLength(50, ErrorMessage ="O nome da categoria deve ter no máximo 50 caracteres")]
    public string category { get; set; }

    [Required]
    public DateTime dateCreated { get; set; } 

    [Required]
    [StringLength(50, ErrorMessage ="O nome do titulo deve ter no máximo 50 caracteres")]
    public string title { get; set; }

    [Required]
    public double price { get; set; }

    [Required]
    public bool priceNegociable { get; set; }

    [Required]
    public string description { get; set; }

    [Required]
    public int views { get; set; }

    [Required]
    public string status { get; set; }
}
