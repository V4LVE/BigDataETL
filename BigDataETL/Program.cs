using BigDataETL.Repository.Domain;
using BigDataETL.Repository.Interfaces;
using BigDataETL.Service.API;
using BigDataETL.Service.Interfaces;
using BigDataETL.Service.Services;
using Microsoft.EntityFrameworkCore;
using ToDoList.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DI Container
builder.Services.AddScoped<FlightAPIService>();
builder.Services.AddScoped<MappingService>();

builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IFlightService, FlightService>();
#endregion


builder.Services.AddDbContext<BigDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LaptopCon"))
    .EnableSensitiveDataLogging(), ServiceLifetime.Singleton);


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
