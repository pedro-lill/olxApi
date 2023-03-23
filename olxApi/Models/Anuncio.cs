using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace olxApi.Models;

public class Anuncio
{
    [Key]
    [Required]
    public int _id { get; set; }

    public DateTime dateCreated { get; set; } = DateTime.Now;

    [Required]
    public string? title { get; set; }

    [Required]
    public double price { get; set; }

    [Required]
    public bool priceNeg { get; set; }

    [Required]
    public string? desc { get; set; }

    public int views { get; set; } = 0;

    public string? status { get; set; }

    public int category_id { get; set; } // essa propriedade representa a foreign key

    public int state_id { get; set; } // essa propriedade representa a foreign key

    public int user_id { get; set; } // essa propriedade representa a foreign key

    public virtual Category ?category { get; set; }
    public virtual State ?state { get; set; }
    public virtual User ?user { get; set; }
    public virtual List<Image> ?images { get; set; }


}
