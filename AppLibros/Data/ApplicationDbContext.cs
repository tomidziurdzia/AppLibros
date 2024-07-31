using AppLibros.Models;
using Microsoft.EntityFrameworkCore;

namespace AppLibros.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    { }
    
    // Colocamos cada uno de los modelos
    public DbSet<Libro> Libro;
}