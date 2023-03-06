using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace olxApi.Models;

public class Anuncio
{
    [Key]
    [Required]
    public int _id { get; set; }

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
    public string? status { get; set; }

    public int category_id { get; set; } // essa propriedade representa a foreign key

    public int state_id { get; set; } // essa propriedade representa a foreign key

    public int user_id { get; set; } // essa propriedade representa a foreign key

    public Category category { get; set; }
    public State state { get; set; }
    public User user { get; set; }

}
