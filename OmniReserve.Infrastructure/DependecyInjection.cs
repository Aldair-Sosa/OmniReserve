using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Configuration;
using OmniReserve.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using OmniReserve.Infrastructure.Persistence;
using OmniReserve.Infrastructure.Persistence.Repositories;
using OmniReserve.Infrastructure.Security;

namespace OmniReserve.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {


        services.AddDbContext<ApplicationDbContext>(options => 
        options.UseNpgsql(configuration.GetConnectionString("OmniReserveDb")));
       
        services.AddScoped<IRoomRepository, RoomRepository>(); 
        services.AddScoped<IReservationRepository, ReservationRepository>();

        //Servicio para el hasheo de contraseñas utilizando BCrypt Compilacion de manera correcta
        services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
        
        return services;
    }
}