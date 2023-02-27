using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace olxApi.Dtos;
public class ReadAnuncioDto
{
    [ForeignKey("User")]
    public string user_id { get; set; }

    [ForeignKey("State")]
    public string state_id { get; set; }

    [ForeignKey("Category")]
    public string category_id { get; set; }
    public DateTime dateCreated { get; set; } 
    public string title { get; set; }
    public double price { get; set; }
    public bool priceNeg { get; set; }
    public string desc { get; set; }
    public int views { get; set; }
    public string status { get; set; }
 }