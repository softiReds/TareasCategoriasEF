using System.ComponentModel.DataAnnotations;

namespace projectef.Models;

public class Categoria
{
    public Guid CategoriaId { get; set; }

    public string CategoriaNombre { get; set; }
    public string CategoriaDescripcion { get; set; }
    public int CategoriaPeso { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; }
}