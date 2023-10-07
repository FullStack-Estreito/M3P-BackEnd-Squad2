using Backend.Context;
using Backend.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// // Add Fluent
builder.Services.AddControllers().AddFluentValidation(config =>
{
    config.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// string connectionString = "Data Source=/Users/mariacarolinaboabaid/Downloads/Senai/LabSchoolContext.db;";

// Injeção de dependência LabSchoolContext
// builder.Services.AddDbContext<LabSchoolContext>(options => options.UseSqlite(connectionString));
builder.Services.AddDbContext<LabSchoolContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LabSchoolContext")));


//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

