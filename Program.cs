using Microsoft.AspNetCore.Mvc;
using ApiFinanzas;
using Microsoft.EntityFrameworkCore;
using ApiFinanzas.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<FinanzasContext>(builder.Configuration.GetConnectionString("cnTareas"));
builder.Services.AddScoped<IEgresoService, EgresoService>();
builder.Services.AddScoped<IIngresoService, IngresoService>();

var app = builder.Build();

app.MapGet("/dbconexion", async ([FromServices] FinanzasContext dbContext) =>
{
    // Devuelve true 
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
