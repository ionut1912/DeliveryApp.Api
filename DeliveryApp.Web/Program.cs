using DeliveryApp.Aplication.Extensions;
using DeliveryApp.Aplication.Middlewares;
using DeliveryApp.ExternalServices.Cloudinary.Settings;
using DeliveryApp.ExternalServices.Extensions;
using DeliveryApp.ExternalServices.MailSending.Settings;
using DeliveryApp.Repository;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.RegisterRepositoryServices(builder.Configuration);
builder.Services.RegisterApplicationServices();
builder.Services.RegisterExternalServices();
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("Cloudinary"));
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));


var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
}


app.UseRouting();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors(opt => { opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:3000"); });

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.Run();