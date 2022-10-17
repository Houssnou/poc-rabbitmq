using POC.EventBus.Extensions;
using POC.Transfer.API.Extensions;
using POC.Transfer.API.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); builder.Services.AddDbContextServices(builder.Configuration);
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

//fire up 
await app.RunAsync();

