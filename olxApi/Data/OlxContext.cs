using olxApi.Models;
using Microsoft.EntityFrameworkCore;

namespace olxApi.Data;

/// <summary>
/// Olx Context
/// </summary>
public class OlxContext : DbContext
{
    public OlxContext(DbContextOptions<OlxContext> options) 
        : base(options)
    {

    }
    /// <summary>
    /// Anuncios
    /// </summary>
    public DbSet<Anuncio> Anuncios { get; set; }  
    /// <summary>
    /// Categories
    /// </summary>
    public DbSet<State> States { get; set; }    
    /// <summary>
    /// Users
    /// </summary>
    public DbSet<User> Users { get; set; }
    /// <summary>
    /// Categories
    /// </summary>
    public DbSet<Category> Categories { get; set; }    


}
