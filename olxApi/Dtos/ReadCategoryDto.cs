using System.ComponentModel.DataAnnotations;
namespace olxApi.Dtos;
/// <summary>
/// The category's data transfer object
/// </summary>
public class ReadCategoryDto
{
    public string? name { get; set; }

    public string? slug { get; set; }

    public string? img { get; set; }
}