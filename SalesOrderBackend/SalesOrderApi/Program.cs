// using Microsoft.EntityFrameworkCore;
// using SalesOrderApi.Models;

// var builder = WebApplication.CreateBuilder(args);

// // Add services
// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// // 👇 ADD THIS LINE
// builder.Services.AddCors();

// // Add SQLite database
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlite("Data Source=salesorder.db"));

// var app = builder.Build();

// // Configure pipeline
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// // 👇 ADD THESE LINES (MUST be BEFORE UseAuthorization)
// app.UseCors(policy => policy
//     .AllowAnyOrigin()
//     .AllowAnyMethod()
//     .AllowAnyHeader());

// app.UseAuthorization();
// app.MapControllers();

// // Auto-create database and seed data
// using (var scope = app.Services.CreateScope())
// {
//     var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//     context.Database.EnsureCreated();
// }

// app.Run();

using Microsoft.EntityFrameworkCore;
using SalesOrderApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 👇 ADD CORS SERVICE
builder.Services.AddCors();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=salesorder.db"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 👇 ADD CORS MIDDLEWARE (MUST be before UseAuthorization)
app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

app.Run();