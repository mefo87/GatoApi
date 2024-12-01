using Business.Donos;
using Business.Gatos;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Configuration;

public static class DependencyInjection
{
    public static void AddBusinessDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IGatoService, GatoService>();
        services.AddScoped<IDonoService, DonoService>();
    }
}