using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SuperChatsWebAPI.Data;
using SuperChatsWebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SuperChatsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SuperChatsContext") ?? throw new InvalidOperationException("Connection string 'SuperChatsContext' not found."))
    .UseLazyLoadingProxies());
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<SuperChatsContext>();
builder.Services.Configure<IdentityOptions>(options =>       //pour les requirements des mots de passes
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//app c'est les pipelines
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();  //doit etre avant authorization
app.UseAuthorization();  //déjà là de base

app.MapControllers();

app.Run();
