using Backend.Context;
using Backend.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using Backend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;



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



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddScoped<UsuarioRepository>();

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

builder.Services.AddTransient<UsuarioRepository, UsuarioRepository>();

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

