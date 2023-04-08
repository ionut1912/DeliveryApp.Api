using DeliveryApp.Application.Extensions;
using DeliveryApp.Application.Middlewares;
using DeliveryApp.ExternalServices.Cloudinary.Settings;
using DeliveryApp.ExternalServices.Extensions;
using DeliveryApp.ExternalServices.MailSending.Settings;
using DeliveryApp.Repository;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.RegisterApplicationServices();
builder.Services.RegisterRepositoryServices(builder.Configuration);
builder.Services.RegisterExternalServices();
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("Cloudinary"));
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));


var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:4000",
        "http://localhost:4001", "http://localhost:4002");
});

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.Run();