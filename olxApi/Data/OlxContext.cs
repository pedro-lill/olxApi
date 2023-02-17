using olxApi.Models;
using Microsoft.EntityFrameworkCore;

namespace olxApi.Data;

public class OlxContext : DbContext
{
    public OlxContext(DbContextOptions<OlxContext> options) 
        : base(options)
    {

    }
    public DbSet<Anuncio> ListAnuncios { get; set; }  
    public DbSet<State> ListStates { get; set; }    
    public DbSet<User> ListUsers { get; set; }
    public DbSet<Category> ListCategories { get; set; }    


}
