using AppLibros.Data;
using AppLibros.Models;
using Microsoft.EntityFrameworkCore;

namespace AppLibros.Repository;

public class Repository : IRepository
{
    private readonly ApplicationDbContext _context;
    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Libro> CrearLibro(Libro crearLibro)
    {
        if (crearLibro != null)
        {
            crearLibro.FechaCreacion = DateTime.Now;
            await _context.Libro.AddAsync(crearLibro);
            await _context.SaveChangesAsync();
            return crearLibro;
        }
        else
        {
            return new Libro();
        }
    }
    
    public async Task<Libro> ActualizarLibro(int libroId, Libro actualizarLibro)
    {
        var librodesdeDB = await _context.Libro.FindAsync(libroId);
        librodesdeDB.Titulo = actualizarLibro.Titulo;
        librodesdeDB.Autor = actualizarLibro.Autor;
        librodesdeDB.Paginas = actualizarLibro.Paginas;
        librodesdeDB.Precio = actualizarLibro.Precio;
        librodesdeDB.Descripcion = actualizarLibro.Descripcion;

        await _context.SaveChangesAsync();
        return librodesdeDB;
    }
    
    public async Task<List<Libro>> GetLibros()
    {
        return await _context.Libro.ToListAsync();
    }

    public async Task<Libro> GetLibroId(int libroId)
    {
        var librodesdeDB = await _context.Libro.FindAsync(libroId);
        if (librodesdeDB == null) return new Libro();

        return librodesdeDB;
    }
    
    public async Task EliminarLibro(int libroId)
    {
        var libroDesdeDB = await _context.Libro.FindAsync(libroId);
        _context.Remove(libroDesdeDB);
        await _context.SaveChangesAsync();
    }
}