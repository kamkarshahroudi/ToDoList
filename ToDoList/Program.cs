

using AutoMapper;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;

using ToDoList.BusinessLayer.Services;
using ToDoList.Configuration;
using ToDoList.DataLayer.Interfaces;
using ToDoList.DataLayer.Model;
using ToDoList.DataLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Create Connection String and DbContext
var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<DbContextApplication>(x => x.UseSqlServer(connectionString));
//Add Services
builder.Services.AddTransient<IToDoList, ToDoListRepository>();
builder.Services.AddTransient<IUnitOfWorkService, UnitOfWorkService>();
builder.Services.AddTransient<IServiceToDoListI, ServiceToDoListI>();
//Add Mapper for converting
IMapper mapper = MappingConfiguration.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
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
app.UseRouting();
app.UseCors("corsapp");
app.UseAuthorization();

app.MapControllers();

app.Run();
