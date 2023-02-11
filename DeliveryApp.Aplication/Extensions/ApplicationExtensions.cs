using DeliveryApp.Aplication.Mediatr;
using DeliveryApp.Aplication.Pipelines;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryApp.Aplication.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        var mediatrAssembly = typeof(MediatrAssemblyReference).Assembly;
        services.AddMediatR(mediatrAssembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(mediatrAssembly);
        return services;
    }
}