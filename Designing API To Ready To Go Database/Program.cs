using System.Security.Cryptography;
using System.Text;
using Designing_API_To_Ready_To_Go_Database.Data;
using Designing_API_To_Ready_To_Go_Database.Interfaces;
using Designing_API_To_Ready_To_Go_Database.Models;
using Designing_API_To_Ready_To_Go_Database.Repositories;
using Designing_API_To_Ready_To_Go_Database.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(options => 
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option => 
{
    option.TokenValidationParameters =
    new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"]!,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"]!,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]!))
    };
});

builder.Services.AddDbContext<MarketContext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{ 
    options.SerializerSettings.ReferenceLoopHandling 
    = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});


builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPasswordHasher<Musteriler>, PasswordHasher<Musteriler>>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IMusteriRepository, MusteriRepository>();
builder.Services.AddScoped<ISiparisRepository, SiparisRepository>();
builder.Services.AddScoped<ISiparisDetayRepository, SiparisDetayRepository>();
builder.Services.AddScoped<IUrunlerRepository, UrunlerRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
