using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectef.Models;

public class Tarea
{
    public Guid TareaId { get; set; }

    public Guid CategoriaId { get; set; }

    public string TareaTitulo { get; set; }
    public string DescripcionTarea { get; set; }
    public Prioridad PrioridadTarea { get; set; }
    public DateTime TareaCreacion { get; set; }

    public virtual Categoria Categoria { get; set; }

    public string Resumen { get; set; }
}

public enum Prioridad
{
    Baja,
    Media,
    Alta
}