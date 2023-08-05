using System.ComponentModel.DataAnnotations;

namespace projectef.Models;

public class Categoria
{
    [Key]
    public Guid CategoriaId { get; set; }

    [Required]
    [MaxLength(150)]
    public string CategoriaNombre { get; set; }
    public string CategoriaDescripcion { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; }
}