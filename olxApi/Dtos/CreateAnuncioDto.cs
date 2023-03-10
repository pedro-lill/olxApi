using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace olxApi.Dtos;

public class CreateAnuncioDto
{
    [ForeignKey("user_id")]
    [Required]
    public int user_id { get; set; }

    [ForeignKey("state_id")]
    [Required]
    public int state_id { get; set; }

    [ForeignKey("category_id")]
    [Required]
    public int category_id { get; set; }

    [Required]
    public DateTime dateCreated { get; set; } 

    [Required]
    [StringLength(50, ErrorMessage ="O nome do titulo deve ter no máximo 50 caracteres")]
    public string? title { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage ="O preço deve ser maior que 0")]
    public double price { get; set; }

    [Required]
    public bool priceNeg { get; set; }

    [Required]
    [StringLength(400, ErrorMessage ="A descrição deve ter no máximo 400 caracteres")]
    public string? desc { get; set; }

    [Required]
    public int views { get; set; }

    [Required]
    public string? status { get; set; }
}