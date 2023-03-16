using System.ComponentModel.DataAnnotations;

namespace olxApi.Dtos;

public class UpdateUserDto
{
    public string? name { get; set; }

    public string? email { get; set; }
    
    public int state_id { get; set; }

    public string? password { get; set; }

    public string? token { get; set; }
}