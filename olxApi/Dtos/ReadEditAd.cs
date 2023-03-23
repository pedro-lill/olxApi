using olxApi.Models;
namespace olxApi.Dtos;
public class ReadEditAd
{
    public int _id { get; set; }
    public int category_id { get; set; }
    public int state_id { get; set; }
    public string title { get; set; }
    public double price { get; set; }
    public bool priceNeg { get; set; }
    public string desc { get; set; }
    public  State ?state { get; set; }
    public  Category ?category { get; set; }
    public List<Image> ?images { get; set; }
}