using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using webapi.middlewares;
using webapi.providers;
using webapi.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<WebapiDBContext>(options =>
{
  var conn = builder.Configuration.GetConnectionString("Webapi") ?? "";
  var match = Regex.Match(conn, @"(mssql|mysql)://(.+)");
  if (match.Success)
  {
    conn = match.Groups[2].Value;
    switch (match.Groups[1].Value)
    {
      case "mssql":
        options.UseSqlServer(conn, b => b.MigrationsAssembly("webapi"));
        break;
      case "mysql":
        options.UseMySql(conn,
                         MariaDbServerVersion.Create(new Version(11, 8), ServerType.MariaDb),
                         b => b.MigrationsAssembly("webapi"));
        break;
    }
  }
});
builder.Services.AddProjectServicesRegistraction();
builder.Services.AddWebapiServicesRegistration();
builder.Services
  .AddControllers(options =>
  {
    options.ModelBinderProviders.Insert(0, new ModelBinderProvider());
  })
  .AddJsonOptions(options =>
  {
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
  });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
  app.MapWebapiMigration();
}

app.UseHttpsRedirection();
app.UseResult();
app.UseIdentity();
app.MapControllers();

app.Run();
