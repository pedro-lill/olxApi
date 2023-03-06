using olxApi.Models;
using Microsoft.EntityFrameworkCore;

namespace olxApi.Data;

public class OlxContext : DbContext
{
    public OlxContext(DbContextOptions<OlxContext> options) 
        : base(options)
    {

    }
    public DbSet<Anuncio> Anuncios { get; set; }  
    
    public DbSet<State> States { get; set; }    

    public DbSet<User> Users { get; set; }
    
    public DbSet<Category> Categories { get; set; }  

    public DbSet<Image> Images { get; set; }
}
