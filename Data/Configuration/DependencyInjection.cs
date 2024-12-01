using Data.Donos;
using Data.Gatos;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Configuration;

public static class DependencyInjection
{
    public static void AddDataDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IGatoRepository, GatoRepository>();
        services.AddScoped<IDonoRepository, DonoRepository>();
    }
}