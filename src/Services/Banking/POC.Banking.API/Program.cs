using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using POC.Banking.API.Extensions;
using POC.Banking.Infrastructure.Data;
using POC.EventBus.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<BankingDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Banking")));
builder.Services.AddApplicationServices();
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddEventBusServices();
builder.Services.AddSwaggerDocumentation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
