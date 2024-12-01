using Business.Configuration;
using Data.Configuration;

namespace GatoApi.Configuration;

public static class DependencyInjection
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        services.AddBusinessDependencyInjection();
        services.AddDataDependencyInjection();
    }
}