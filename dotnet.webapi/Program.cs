using System.Text.Json.Serialization;
using Asp.Versioning;
using dotnet.Attributes;
using dotnet.Middlewares;
using dotnet.Providers;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
       .AddControllers(options =>
       {
         options.ModelBinderProviders.Insert(0, new ModelBinderProvider());
         options.Filters.Add<ApiControllerAttribute>();
         options.Filters.Add<AuthorizationFilter>();
         //options.Filters.Add<ExceptionFilterAttribute>();
         options.Filters.Add<ResultFilterAttribute>();
       })
       .AddJsonOptions(options =>
       {
         options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
         options.JsonSerializerOptions.Converters.Add(new JsonDatetimeOffsetProvider());
       });

builder.Services
       .AddApiVersioning(options =>
       {
         options.DefaultApiVersion = new ApiVersion(1, 0);
         options.AssumeDefaultVersionWhenUnspecified = true;
         options.ReportApiVersions = true;
         options.ApiVersionReader = new UrlSegmentApiVersionReader();
       })
       .AddApiExplorer(options =>
       {
         options.GroupNameFormat = "'v'VVV";
         options.SubstituteApiVersionInUrl = true;
       });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseException();
//app.UseLogger();
app.UseAuthorization();

app.MapControllers();

app.Run();
