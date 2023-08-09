using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace projectef.Context;

public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("e1a0019d-5685-4af5-8f81-d64ebad9bd00"), CategoriaNombre = "Actividades pendientes", CategoriaPeso = 20 });
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("e1a0019d-5685-4af5-8f81-d64ebad9bd01"), CategoriaNombre = "Actividades personales", CategoriaPeso = 50 });

        builder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);

            categoria.Property(p => p.CategoriaNombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.CategoriaDescripcion).IsRequired(false);
            categoria.Property(p => p.CategoriaPeso);

            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();

        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("e1a0019d-5685-4af5-8f81-d64ebad9bd02"), CategoriaId = Guid.Parse("e1a0019d-5685-4af5-8f81-d64ebad9bd00"), PrioridadTarea = Prioridad.Media, TareaTitulo = "Pago de serviciios publicos", TareaCreacion = DateTime.Now });
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("e1a0019d-5685-4af5-8f81-d64ebad9bd03"), CategoriaId = Guid.Parse("e1a0019d-5685-4af5-8f81-d64ebad9bd01"), PrioridadTarea = Prioridad.Baja, TareaTitulo = "Terminar de ver pelicula en netflix", TareaCreacion = DateTime.Now });

        builder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.TareaId);

            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);

            tarea.Property(p => p.TareaTitulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.DescripcionTarea).IsRequired(false);
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.TareaCreacion);

            tarea.Ignore(p => p.Resumen);

            tarea.HasData(tareasInit);
        });
    }
}