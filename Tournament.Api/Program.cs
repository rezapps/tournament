using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Tournament.Core.Repositories;
using Tournament.Data.Data;
using Tournament.Data.Repositories;
using Tournament.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register services for Controller
builder.Services.AddControllers(options => options.ReturnHttpNotAcceptable = true)
    .AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();

// Register services for Database
builder.Services.AddDbContext<TournamentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services for Repositories
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<ITourneyRepository, TourneyRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(TournamentMappings)); 

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

app.UseAuthorization();

app.MapControllers();

app.Run();
