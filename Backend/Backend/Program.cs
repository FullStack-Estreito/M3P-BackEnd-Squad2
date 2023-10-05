using Backend.Context;
using Backend.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// string connectionString = "Data Source=/Users/mariacarolinaboabaid/Downloads/Senai/LabSchoolContext.db;";

// Injeção de dependência LabSchoolContext
// builder.Services.AddDbContext<LabSchoolContext>(options => options.UseSqlite(connectionString));
builder.Services.AddDbContext<LabSchoolContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LabSchoolContext")));


//Repositories
builder.Services.AddScoped<UsuarioRepository>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

