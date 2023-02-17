using System.ComponentModel.DataAnnotations;
namespace olxApi.Dtos;
public class ReadCategoryDto
{
    public int _id { get; set; }
    public string name { get; set; }
    public string slug { get; set; }
 }