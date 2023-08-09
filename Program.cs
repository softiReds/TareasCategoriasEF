using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef.Context;
using projectef.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("LocalConnection"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();

    return Results.Ok("Conexión con la base de datos establecida correctamente");
});

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas.Include(p => p.Categoria));
});

app.MapGet("/api/tareas/filtro", async ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas.Include(p => p.Categoria).Where(p => p.PrioridadTarea == projectef.Models.Prioridad.Baja));
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.TareaCreacion = DateTime.Now;

    await dbContext.Tareas.AddAsync(tarea);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{
    var tareaActual = dbContext.Tareas.Find(id);

    if (tareaActual != null)
    {
        tareaActual.CategoriaId = tarea.CategoriaId;
        tareaActual.TareaTitulo = tarea.TareaTitulo;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        tareaActual.DescripcionTarea = tarea.DescripcionTarea;

        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();
});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) =>
{
    var tareaActual = dbContext.Tareas.Find(id);

    if (tareaActual != null)
    {
        dbContext.Remove(tareaActual);

        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();
});

app.Run();