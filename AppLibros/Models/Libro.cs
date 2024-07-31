using System.ComponentModel.DataAnnotations;

namespace AppLibros.Models;

public class Libro
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "El titulo es obligatorio")]
    public string Titulo { get; set; }
    
    [Required(ErrorMessage = "La descripcion es obligatoria")]
    public string Descripcion { get; set; }
    
    [Required(ErrorMessage = "El autor es obligatorio")]
    public string Autor { get; set; }
    
    [Required(ErrorMessage = "La cantidad de paginas es obligatorias")]
    public int Paginas { get; set; }
    
    [Required(ErrorMessage = "El precio es obligatorias")]
    public int Precio { get; set; }
    
    public DateTime FechaCreacion { get; set; }
}
