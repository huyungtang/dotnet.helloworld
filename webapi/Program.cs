using webapi.services;
using webapi.middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<WebapiContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Webapi")));
builder.Services.AddProjectServicesRegistraction();
builder.Services.AddWebapiServicesRegistration();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseResult();
app.UseIdentity();
app.MapControllers();

app.Run();
