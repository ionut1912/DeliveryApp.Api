using DeliveryApp.Application.Mediatr;
using DeliveryApp.Application.Pipelines;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryApp.Application.Extensions;

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