using System.ComponentModel.DataAnnotations;
namespace olxApi.Dtos;
public class ReadUserDto
{
    public string name { get; set; }
    public string email { get; set; }
    public int state_id { get; set; }
    public string password { get; set; }
    public string token { get; set; }
    
    public List<ReadEditAd> ads { get; set; }
 
 }