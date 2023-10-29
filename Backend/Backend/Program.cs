﻿using System.Reflection;
using Backend.Context;
using Backend.Repositories;
using Backend.Repositories.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddControllers().AddJsonOptions(x =>
//    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

builder.Services.AddControllers()
    .AddFluentValidation(options =>
    {
        // Validate child properties and root collection elements
        options.ImplicitlyValidateChildProperties = true;
        options.ImplicitlyValidateRootCollectionElements = true;

        // Automatic registration of validators in assembly
        options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//string connectionString = "Data Source=/Users/mariacarolinaboabaid/Downloads/Senai/LabSchoolContext.db;";

// string connectionString = "Data Source=/Users/mariacarolinaboabaid/Downloads/Senai/LabSchoolContext.db;";

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//Token

var Key = Encoding.ASCII.GetBytes(Backend.Service.Key.Secret);


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
//Repositories
builder.Services.AddScoped<IAtendimentosRepository, AtendimentosRepository>();
builder.Services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
builder.Services.AddScoped<IExercicioRepository, ExercicioRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// string connectionString = "Data Source=/Users/mariacarolinaboabaid/Downloads/BANCO/fichaCadastro.db;";
// builder.Services.AddDbContext<LabSchoolContext>(options => options.UseSqlite(connectionString));

builder.Services.AddDbContext<LabSchoolContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LabSchoolContext")));

// Automapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(c =>{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();