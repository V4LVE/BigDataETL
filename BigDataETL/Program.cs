using BigDataETL.Repository.Domain;
using BigDataETL.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DI Container
builder.Services.AddScoped<ApiCaller>();
#endregion

builder.Services.AddDbContext<BigDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LaptopCon"));
    //options.UseSqlServer(builder.Configuration.GetConnectionString("DesktopCon"));
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
