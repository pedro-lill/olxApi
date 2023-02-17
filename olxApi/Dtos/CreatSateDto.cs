using System.ComponentModel.DataAnnotations;

namespace olxApi.Dtos;

public class CreateStateDto
{   
    // state has a 2 elements _id, name
    [Required]
    [MaxLength(50)]
    public string _id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string name { get; set; }

}

