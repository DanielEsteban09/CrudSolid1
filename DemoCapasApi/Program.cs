using CapaDatos;
using CapaNegocio.Clases;
using CapaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configurar el acceso a datos
var conn = builder.Configuration.GetConnectionString("AppConnection");  //Creamos una variable que contiene la cadena de conexion
builder.Services.AddDbContext<DbSolid1Context>(x=>x.UseSqlServer(conn));  //Creamos el contexto

//Configurar las interfaces para que el controlador las pueda usar
builder.Services.AddScoped<IDato,LogicaDato>();

var app = builder.Build();

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
