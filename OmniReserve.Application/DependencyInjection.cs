using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OmniReserve.Application.Common.Behaviors;
using  System.Reflection;

namespace OmniReserve.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssembly(
        typeof(DependencyInjection).Assembly
            )
        );


        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg => {cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                            cfg.AddBehavior(typeof (IPipelineBehavior<,>), typeof (ValidationBehavior<,>));
        });

        return services;
    }
}