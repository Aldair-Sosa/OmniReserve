using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Configuration;
using OmniReserve.Application.Interfaces;
using OmniReserve.Infrastructure.Peristence.Repositories;
using Microsoft.EntityFrameworkCore;
using OmniReserve.Infrastructure.Peristence;

namespace OmniReserve.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {


        services.AddDbContext<ApplicationDbContext>(options => 
        options.UseNpgsql(configuration.GetConnectionString("OmniReserveDb")));
       
        services.AddScoped<IRoomRepository, RoomRepository>(); 

        
        return services;
    }
}