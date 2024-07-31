using AppLibros.Models;
using Microsoft.EntityFrameworkCore;

namespace AppLibros.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

    }
    
    // Colocamos cada uno de los modelos
    public DbSet<Libro> Libro { get; set; }
}