using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace olxApi.Dtos;

public class CreateAnuncioDto
{
    [Required]
    [ForeignKey("Users")]
    // [StringLength(24, ErrorMessage ="O id do usuário deve ter no máximo 24 caracteres")]
    // [RegularExpression(@"^[a-fA-F0-9]{24}$", ErrorMessage ="O id do usuário deve ser um ObjectId válido")]
    // [Display(Name = "Id do usuário")]
    public string idUser { get; set; }

    [Required]
    [StringLength(50, ErrorMessage ="O nome do estado deve ter no máximo 50 caracteres")]
    public string state { get; set; }

    [Required]
    [StringLength(50, ErrorMessage ="O nome da categoria deve ter no máximo 50 caracteres")]
    public string cat { get; set; }

    [Required]
    public DateTime dateCreated { get; set; } 

    [Required]
    [StringLength(50, ErrorMessage ="O nome do titulo deve ter no máximo 50 caracteres")]
    public string title { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage ="O preço deve ser maior que 0")]
    public double price { get; set; }

    [Required]
    public bool priceNeg { get; set; }

    [Required]
    [StringLength(400, ErrorMessage ="A descrição deve ter no máximo 400 caracteres")]
    public string desc { get; set; }

    [Required]
    public int views { get; set; }

    [Required]
    public string status { get; set; }

}