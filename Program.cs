using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MonqLab_test_task.BL;
using MonqLab_test_task.Common.Middlewares;
using MonqLab_test_task.Infrastructure.Context;
using MonqLab_test_task.Infrastructure.Repository;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Example API", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
var config = builder.Configuration;
string mailKitSetting = "MailKitSettings";
builder.Services.AddMailKit(optionBuilder =>
{
    optionBuilder.UseMailKit(new MailKitOptions()
    {
        Server = config.GetSection($"{mailKitSetting}:Server").Value,
        Port = Convert.ToInt32(config.GetSection($"{mailKitSetting}:Port").Value),
        SenderName = config.GetSection($"{mailKitSetting}:SenderName").Value,
        SenderEmail = config.GetSection($"{mailKitSetting}:SenderEmail").Value,
        Password = config.GetSection($"{mailKitSetting}:Password").Value,
        Security = true
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(config.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);

builder.Services.AddTransient<IUseCaseDataBL, UseCaseDataBL>();
builder.Services.AddTransient<IEmailDataRepository, EmailDataRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<ExceptionMiddleware>();
app.Run();