using CreditSimulationApp.BLL.DTOs;
using CreditSimulationApp.BLL.Repositories.Implements;
using CreditSimulationApp.BLL.Repositories;
using CreditSimulationApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using CreditSimulationApp.BLL.Services;
using CreditSimulationApp.BLL.Services.Implements;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CreditSimulationDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IClienteRepository, ClienteRepository>(); 
builder.Services.AddScoped<ICreditoRepository, CreditoRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ICreditoService, CreditoService>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
