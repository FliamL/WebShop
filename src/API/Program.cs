using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Webshop.API.DbContexts;
using Webshop.API.Entities;
using Webshop.API.Services;
using Webshop.API.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);

#region Repos
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
#endregion

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configure EF Core with SQL Server
builder.Services.AddDbContext<WebshopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:WebshopDBConnectionString"]);
});

// Configure Identity Core
builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<WebshopDbContext>()
    .AddDefaultTokenProviders(); // Needed for generating refresh tokens, password reset tokens, etc.

// Configure JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"], // Set in appsettings.json
        ValidAudience = builder.Configuration["Jwt:Audience"], // Set in appsettings.json
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
    };
});

builder.Services.AddAuthorization(); // Authorization middleware

// Add Swagger
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

app.UseAuthentication(); // Apply the JWT authentication middleware
app.UseAuthorization();

app.MapControllers();

app.Run();