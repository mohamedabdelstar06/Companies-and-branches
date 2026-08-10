using System;
using System.Linq;
using System.Reflection;
using ZAD.Application.Interfaces;
using ZAD.Application.Mapping;
using ZAD.Application.Validators;
using ZAD.Domain.Interfaces;
using ZAD.Persistence.Context;
using ZAD.Persistence.Repositories;
using ZAD.WebAPI.Filters;
using ZAD.WebAPI.Middleware;
using ZAD.WebAPI.Services;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var logPath = System.IO.Path.Combine(AppContext.BaseDirectory, "Logs", "log-.txt");
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(logPath, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 14)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();

var appAssembly = typeof(IAppService).Assembly;
var serviceTypes = appAssembly.GetTypes()
    .Where(t => t.IsClass && !t.IsAbstract && typeof(IAppService).IsAssignableFrom(t));

foreach (var type in serviceTypes)
{
    var interfaceType = type.GetInterfaces().First(i => i != typeof(IAppService));
    builder.Services.AddScoped(interfaceType, type);
}

builder.Services.AddAutoMapper(cfg => 
{
    cfg.AddProfile<CompanyProfile>();
    cfg.AddProfile<BranchProfile>();
});

builder.Services.AddValidatorsFromAssemblyContaining<CreateCompanyDtoValidator>();
builder.Services.AddScoped<ValidationFilterAttribute>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        b => b.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseSerilogRequestLogging();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var db = services.GetRequiredService<ApplicationDbContext>();
        db.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<Microsoft.Extensions.Logging.ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
