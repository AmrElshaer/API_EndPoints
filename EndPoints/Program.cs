using AutoMapper;
using EndPoints;
using EndPoints.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMappingProfile());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data source=endpoint.sqlite"));
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
