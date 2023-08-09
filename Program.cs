using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef.Context;

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
    return Results.Ok(dbContext.Tareas);
});

app.MapGet("/api/tareas/filtro", async ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas.Where(p => p.PrioridadTarea == projectef.Models.Prioridad.Baja));
});

app.Run();