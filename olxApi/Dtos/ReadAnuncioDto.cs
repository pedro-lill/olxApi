using System.ComponentModel.DataAnnotations;
namespace olxApi.Dtos;
public class ReadAnuncioDto
{
    public string idUser { get; set; }
    public string state { get; set; }
    public string category { get; set; }
    public DateTime dateCreated { get; set; } 
    public string title { get; set; }
    public double price { get; set; }
    public bool priceNegociable { get; set; }
    public string description { get; set; }
    public int views { get; set; }
    public string status { get; set; }
 }