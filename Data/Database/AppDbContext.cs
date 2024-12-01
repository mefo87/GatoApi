using Data.Donos;
using Data.Gatos;
using Data.Gatos.GatoFotos;
using Microsoft.EntityFrameworkCore;

namespace Data.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Gato> Gatos { get; init; }
    public DbSet<Dono> Donos { get; init; }
    public DbSet<GatoFoto> GatoFotos { get; init; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}