using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SuperChatsWebAPI.Data;
using SuperChatsWebAPI.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SuperChatsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SuperChatsContext") ?? throw new InvalidOperationException("Connection string 'SuperChatsContext' not found."))
    .UseLazyLoadingProxies());

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<SuperChatsContext>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
});

builder.Services.AddAuthentication(options =>    //Faut faire apr�s configure identityoption
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;      // pour permettre au user de save ou pas
    options.RequireHttpsMetadata = false; // En d�veloppement seulement
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidAudience = "http://localhost:4200",
        ValidIssuer = "https://localhost:7096",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))   //JWT:Secret c'est dans appsettings.json
    };
});

builder.Services.AddControllers();


builder.Services.AddCors(options => {
    options.AddPolicy("Allowall", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
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

app.UseCors("Allowall");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
