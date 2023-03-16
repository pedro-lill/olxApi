using System.ComponentModel.DataAnnotations;
namespace olxApi.Dtos;
/// <summary>
/// The state's data transfer object
/// </summary>
public class ReadStateDto
{
    public int _id { get; set; }
    public string? name { get; set; }
 }