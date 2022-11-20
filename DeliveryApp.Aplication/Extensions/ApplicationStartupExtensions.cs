using DeliveryApp.Aplication.MailSending;
using DeliveryApp.Aplication.Mediatr;
using DeliveryApp.Aplication.Middlewares;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Aplication.Services;
using DeliveryApp.Domain.Cloudinary.Settings;
using DeliveryApp.Domain.MailSender.Settings;
using DeliveryApp.Domain.Pipelines;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Profiles;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace DeliveryApp.Aplication.Extensions
{
    public static class ApplicationStartupExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
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
            services.AddDbContext<DeliveryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DeliveryConnectionString")));
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithOrigins("http://localhost:3000");
                });
            });

            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();
            services.AddScoped<IMenuItemRepository, MenuItemService>();
            services.AddScoped<IOfferRepository, OfferService>();
            services.AddScoped<IOrderRepository, OrderService>();
            services.AddScoped<IPhotoForMenuItemRepository, PhotoForMenuItemService>();
            services.AddScoped<IPhotoRepository, PhotoService>();
            services.AddScoped<IRestaurantRepository, RestaurantService>();
            services.AddScoped<IUserConfigRepository, UserConfigService>();
            services.Configure<CloudinarySettings>(configuration.GetSection("Cloudinary"));
            services.AddAutoMapper(typeof(BaseProfile).Assembly);
            services.AddTransient<ExceptionHandlingMiddleware>();
            var mediatrAssembly = typeof(MediatrAssemblyReference).Assembly;
            services.AddMediatR(mediatrAssembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(mediatrAssembly);
            return services;
        }
    }
}
