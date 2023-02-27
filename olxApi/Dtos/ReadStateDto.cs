using System.ComponentModel.DataAnnotations;
namespace olxApi.Dtos;
/// <summary>
/// The state's data transfer object
/// </summary>
public class ReadStateDto
{
    /// <summary>
    /// The state's name
    /// </summary>
    public string? name { get; set; }
 }