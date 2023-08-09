using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace projectef.Models;

public class Categoria
{
    public Guid CategoriaId { get; set; }

    public string CategoriaNombre { get; set; }
    public string CategoriaDescripcion { get; set; }
    public int CategoriaPeso { get; set; }

    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas { get; set; }
}