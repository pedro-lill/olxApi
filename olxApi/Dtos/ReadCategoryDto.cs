using System.ComponentModel.DataAnnotations;
namespace olxApi.Dtos;
/// <summary>
/// The category's data transfer object
/// </summary>
public class ReadCategoryDto
{
    /// <summary>
    /// The category's name
    /// </summary>
    public string? name { get; set; }
}