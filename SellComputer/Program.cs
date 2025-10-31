using Microsoft.EntityFrameworkCore;
using SellComputer.Data;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

// Đặt biến môi trường 
builder.Configuration.AddEnvironmentVariables();

var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

builder.Services.AddControllers();

// Add DbContext dùng connection string từ .env
builder.Services.AddDbContext<ShopBanMayTinhContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
