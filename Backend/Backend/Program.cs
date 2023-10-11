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




var builder = WebApplication.CreateBuilder(args);

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

string connectionString = "Data Source=/Users/mariacarolinaboabaid/Downloads/Senai/LabSchoolContext.db;";


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//Token

// builder.Services.AddSwaggerGen(x =>
// {

//     x.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
//     {
//         Name = "Authorization",
//         In = ParameterLocation.Header,
//         Type = SecuritySchemeType.ApiKey,
//         Scheme = "Bearer"
//     });

//     x.AddSecurityRequirement(new OpenApiSecurityRequirement()
//     {
//       {
//         new OpenApiSecurityScheme
//         {
//             Reference = new OpenApiReference{
//                 Type = ReferenceType.SecurityScheme,
//                 Id = "Bearer"
//             },
//             Scheme = "oauth2",
//             Name = "Bearer",
//             In = ParameterLocation.Header,
//             },
//             new List<string>()
//         }
//     });

// });


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
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
builder.Services.AddScoped<IExercicioRepository, ExercicioRepository>();
builder.Services.AddScoped<IWhiteLabel, WhiteLabelRepository>();


// Injeção de dependência LabSchoolContext
builder.Services.AddDbContext<LabSchoolContext>(options => options.UseSqlite(connectionString));
// builder.Services.AddDbContext<LabSchoolContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LabSchoolContext")));

// Automapper
builder.Services.AddAutoMapper(typeof(Program));

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