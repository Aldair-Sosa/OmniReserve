namespace Microsoft.Extensions.DependencyInjection; 

namespace OmniReserve.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(IConfiguration configuration)
    {
        return services;
    }
}