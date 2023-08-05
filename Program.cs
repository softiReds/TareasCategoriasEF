using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef.Context;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDbMemory"));
builder.Services.AddSqlServer<TareasContext>("Data Source=softiRedsLaptop;Initial Catalog=EfDb;user id=sa;password=isabella12;TrustServerCertificate=True");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();

    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.Run();