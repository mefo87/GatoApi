using Data.Database;
using Microsoft.EntityFrameworkCore;

namespace GatoApi.Configuration;

public static class DatabaseConfiguration
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Database")));
    }
}