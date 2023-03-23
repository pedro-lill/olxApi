using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using olxApi.Models;

namespace olxApi.Dtos;
public class OtherDto
{

    public int _id { get; set; }
    public string user_id { get; set; }
    public string state_id { get; set; }
    public string category_id { get; set; }
    public DateTime dateCreated { get; set; } 
    public string title { get; set; }
    public double price { get; set; }
    public bool priceNeg { get; set; }
    public string desc { get; set; }
    public int views { get; set; }
    public string status { get; set; }
    public List<Image> ?images { get; set; }
    public Category ?category { get; set; }
    public State ?state { get; set; }
    
    public List<ReadAnuncioDto> ?others { get; set; }

    public OtherDto(ReadAnuncioDto anuncio, List<ReadAnuncioDto> others)
    {
        foreach (var prop in anuncio.GetType().GetProperties())
            this?.GetType()?.GetProperty(prop.Name)?.SetValue(this, prop.GetValue(anuncio));
        this.others = others;
    }
}