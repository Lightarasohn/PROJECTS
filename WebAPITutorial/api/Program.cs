using System.Text;
using api.Data;
using api.Interfaces;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Newtonsoft ile Database veri gösterimindeki sonsuz döngüyü kırabiliriz.
//Fakat ben bu sonsuz döngü gösterimi hatasını NewtonsoftJson kullanmadan DTO lar ile hallettim
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{ 
    options.SerializerSettings.ReferenceLoopHandling 
    = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

//Database bağlama
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

//Database'e Identity eklemek tam olarak bu şekilde yapılır
//Model sınıfı ve Rolünü belirterek database'e eklenir
builder.Services.AddIdentity<AppUser, IdentityRole>(options => 
{
    //Parola gereksinimleri yapılır
    options.Password.RequireDigit = 
    options.Password.RequireLowercase =
    options.Password.RequireNonAlphanumeric =
    options.Password.RequireUppercase = true;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequiredLength = 12;
})
//Daha sonrasında ise Database'e eklenmesi için EntityFrameworkCore kullanılarak database context belirtilir.
.AddEntityFrameworkStores<ApplicationDBContext>( );

//Doğrulama ekleme
builder.Services.AddAuthentication(options =>
{
    //Doğrulama için şemalar belirtilir
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = 
    //Bu durumda JwtBearer'ın default doğrulama şeması kullanılır
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})//Tokenleme için JWT bu şekilde tanımlanır
.AddJwtBearer(optionsjwt => 
{
    optionsjwt.TokenValidationParameters = new TokenValidationParameters
    {
        //Issuer sunucudur
        ValidateIssuer = true,
        //"JWT:Issuer" ./api/appsettings.json dosyasına yazılır ve sunucu adresini belirtir 
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        //Audience kullanıcıdır
        ValidateAudience = true,
        //"JWT:Audience" ./api/appsettings.json dosyasına yazılır ve kullanıcı adresini belirtir
        ValidAudience = builder.Configuration["JWT:Audience"],
        //Secretkey'dir ve JWT'nin Header + Payload,SecretKey yapısında tanışınır
        ValidateIssuerSigningKey = true,
        //IssuerSigningKey bir SecurityKey öğesidir ve yeni bir simetrik security key öğesi oluşturularak tanımlanır
        //"./api/appsettings.json" dosyasında tanımladığımız SiginingKey i encode ederek kullanırız
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]!))
    };
});

//Kullanıcı servisleri bu şekilde projeye eklenir
//Not: Repository eklerken önce Interface ekle
builder.Services.AddScoped<IStockRepository ,StockRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
