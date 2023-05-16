using CarWashSystem;
using CarWashSystem.Data;
using CarWashSystem.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OnDemandDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("CarWashConnectionString")));
builder.Services.AddScoped<IUser,SQLUserRepository>();
builder.Services.AddScoped<IAddon, SQLAddonRepository>();
builder.Services.AddScoped<IWashPackage, SQLWashPackageRepository>();
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
