using ApplicationLayer.Mapping;
using ApplicationLayer.Services;
using CoreLayer.Interfaces.Repositories;
using CoreLayer.Interfaces.ServiceInterfaces;
using InfrasructureLayer.DbConnection;
using InfrasructureLayer.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



//DbContext------------------------------------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//AutoMapper
builder.Services.AddAutoMapper(typeof(MyMapping));

//Repositories---------------------------------
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IEngineRepository, EngineRepositoy>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

//Services-------------------------------------
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IEngineService, EngineService>();
builder.Services.AddScoped<IOrderService, OrderService>();

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