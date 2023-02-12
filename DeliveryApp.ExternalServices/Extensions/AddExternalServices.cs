using DeliveryApp.ExternalServices.Cloudinary;
using DeliveryApp.ExternalServices.Cloudinary.Photo;
using DeliveryApp.ExternalServices.MailSending;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryApp.ExternalServices.Extensions;

public static class AddExternalServices
{
    public static IServiceCollection RegisterExternalServices(this IServiceCollection services)
    {
        services.AddTransient<IMailService, MailService>();
        services.AddTransient<IUserAccessor, UserAccessor>();
        services.AddTransient<IPhotoAccessor, PhotoAccessor>();

        return services;
    }
}