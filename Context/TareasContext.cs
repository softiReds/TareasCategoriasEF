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
        builder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);

            categoria.Property(p => p.CategoriaNombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.CategoriaDescripcion);
            categoria.Property(p => p.CategoriaPeso);
        });

        builder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.TareaId);

            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);

            tarea.Property(p => p.TareaTitulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.DescripcionTarea);
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.TareaCreacion);

            tarea.Ignore(p => p.Resumen);

        });
    }
}