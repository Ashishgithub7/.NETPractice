using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using DataAccess.Data;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//builder.Services.AddAuthentication("Bearer")
//    .AddIdentityServerAuthentication("Bearer", options =>
//    options.Authority = "https://localhost:5443");
//options.ApiName = "CoffeeAPI";

//CoffeeAPI defines api resources to be protected

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:5443"; // URL of IdentityServer
        options.Audience = "CoffeeAPI"; // API name (must match what's configured in IdentityServer)
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });


builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICoffeeShopService, CoffeeShopService>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
