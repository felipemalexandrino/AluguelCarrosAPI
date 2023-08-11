using AluguelCarros.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// add services to the access database
var connectionString = builder.Configuration.GetConnectionString("AluguelConnection");
builder.Services.AddDbContext<AluguelContext>(opts => opts
    .UseSqlServer(connectionString));


builder.Services
    .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(b => {
    b.EnableAnnotations();
    b.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "DCarAPI",
        Description = "API para Locacao de veiculos."
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
