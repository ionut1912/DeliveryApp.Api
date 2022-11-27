using System.Text;
using DeliveryApp.Aplication.MailSending;
using DeliveryApp.Aplication.Mediatr;
using DeliveryApp.Aplication.Middlewares;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Aplication.Services;
using DeliveryApp.Domain.Cloudinary.Settings;
using DeliveryApp.Domain.MailSender.Settings;
using DeliveryApp.Domain.Pipelines;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using DeliveryApp.Repository.Profiles;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Jwt auth header",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});
builder.Services.AddAutoMapper(typeof(BaseProfile).Assembly);
builder.Services.AddDbContext<DeliveryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DeliveryConnectionString")));
builder.Services.AddCors();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailService, MailService>(); builder.Services.AddScoped<IPhotoAccessor, PhotoAccessor>();
builder.Services.AddScoped<IMenuItemRepository, MenuItemService>();
builder.Services.AddScoped<IOfferRepository, OfferService>();
builder.Services.AddScoped<IOrderRepository, OrderService>();
builder.Services.AddScoped<IPhotoForMenuItemRepository, PhotoForMenuItemService>();
builder.Services.AddScoped<IPhotoRepository, PhotoService>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantService>();
builder.Services.AddScoped<IUserConfigRepository, UserConfigService>();
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("Cloudinary"));
builder.Services.AddAutoMapper(typeof(BaseProfile).Assembly);
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
var mediatrAssembly = typeof(MediatrAssemblyReference).Assembly;
builder.Services.AddMediatR(mediatrAssembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(mediatrAssembly);
builder.Services.AddIdentityCore<Users>(opt => { opt.User.RequireUniqueEmail = true; })
    .AddRoles<Roles>()
    .AddEntityFrameworkStores<DeliveryContext>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration["JWTSettings:TokenKey"]))
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddScoped<TokenService>();


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