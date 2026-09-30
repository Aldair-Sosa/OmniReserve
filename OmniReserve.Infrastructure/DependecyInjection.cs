using Microsoft.Extensions.DependencyInjection; 

using Microsoft.Extensions.Configuration;
using OmniReserve.Application.Interfaces;
using OmniReserve.Infrastructure.Peristence.Repositories;

namespace OmniReserve.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRoomRepository, RoomRepository>(); 
        return services;
    }
}