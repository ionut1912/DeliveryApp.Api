using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DeliveryApp.Aplication.Services;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdenityServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddIdentityCore<Users>(opt => { opt.Password.RequireNonAlphanumeric = false; }).AddRoles<Roles>()
                .AddSignInManager<SignInManager<Users>>().AddEntityFrameworkStores<DeliveryContext>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:TokenKey"]));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddAuthorization();
            services.AddScoped<TokenService>();
            return services;
        }
    }
}
