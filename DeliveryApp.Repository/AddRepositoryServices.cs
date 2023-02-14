using System.Text;
using DeliveryApp.Application.Middlewares;
using DeliveryApp.Application.Repositories;
using DeliveryApp.ExternalServices.MailSending;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using DeliveryApp.Repository.Profiles;
using DeliveryApp.Repository.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DeliveryApp.Repository;

public static class AddRepositoryServices
{
    public static IServiceCollection RegisterRepositoryServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(BaseProfile).Assembly);
        services.AddDbContext<DeliveryContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DeliveryConnectionString")));

        services.AddTransient<IMailService, MailService>();
        services.AddScoped<IMenuItemRepository, MenuItemService>();
        services.AddScoped<IOfferRepository, OfferService>();
        services.AddScoped<IOrderRepository, OrderService>();
        services.AddScoped<IPhotoForMenuItemRepository, PhotoForMenuItemService>();
        services.AddScoped<IPhotoRepository, PhotoService>();
        services.AddScoped<IRestaurantRepository, RestaurantService>();
        services.AddScoped<IUserConfigRepository, UserConfigService>();
        services.AddTransient<ExceptionHandlingMiddleware>();

        services.AddIdentityCore<Users>(opt => { opt.User.RequireUniqueEmail = true; })
            .AddRoles<Roles>()
            .AddEntityFrameworkStores<DeliveryContext>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(configuration["JWTSettings:TokenKey"]))
                };
            });

        services.AddScoped<TokenService>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}