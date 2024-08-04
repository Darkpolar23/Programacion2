using Microsoft.EntityFrameworkCore;
using Apirestaurant.Context;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// variable Conexion para la base de datos 
//var ConnectionString = builder.Configuration.GetConnectionString("connection");
var ConnectionString = builder.Configuration.GetConnectionString("connection");

//OJO: --------------- registrar servicios DB ------------------//
// Recuerda caundo creas un api en un proyecto con varias capas recuerda indicarle donde hara la emigracion

builder.Services.AddDbContext<AppDBcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly("Apirestaurant")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
