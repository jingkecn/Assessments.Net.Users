using Assessments.Users.Application.Extensions;
using Assessments.Users.Command.Api.Extensions;
using Assessments.Users.Infrastructure;
using Assessments.Users.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Docker Compose mode.
builder.Services.AddDbContext<DefaultDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("users-db")));

// .NET Aspire mode.
// builder.AddSqlServerDbContext<DefaultDbContext>("users-db");

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer().AddSwaggerGen();

// Add infrastructure services.
builder.Services.AddInfrastructure();

// Add application services.
builder.Services.AddApplication();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.Services.InitializeInfrastructure();
}

app.UseHttpsRedirection();

app.MapUserApis();

app.Run();

// This class is only used for the test project.
// It is not used in the main project.
public partial class Program;
