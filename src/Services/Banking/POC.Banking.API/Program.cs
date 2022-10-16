using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using POC.Banking.API.Extensions;
using POC.Banking.API.Helpers;
using POC.Banking.Infrastructure.Data;
using POC.EventBus.Extensions;
using System.Reflection;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContextServices(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddEventBusServices();
builder.Services.AddSwaggerDocumentation();

builder.Services.AddAutoMapper(typeof(MappingProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.UseDbContextServices();

//fire up 
await app.RunAsync();
