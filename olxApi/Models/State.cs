using System.ComponentModel.DataAnnotations;
namespace olxApi.Models;
/// <summary>
/// State model
/// </summary>
public class State
{
    /// <summary>
    /// State id
    /// </summary>
    [Key]
    public string _id { get; set; }

    /// <summary>
    /// State name
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string name { get; set; }
}
