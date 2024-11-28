using Data.Database;
using Microsoft.EntityFrameworkCore;

namespace Data.Gatos;

public class GatoRepository(AppDbContext context) : IGatoRepository
{
    public async Task<List<Gato>> GetAllGatosAsync()
    {
        var gatoList = await context.Gatos.ToListAsync();
        return gatoList;
    }

    public async Task CriarGatoAsync(Gato gato)
    {
        await context.Gatos.AddAsync(gato);
        await context.SaveChangesAsync();
    }

    public async Task DeletarGatoAsync(Gato gato)
    {
        context.Gatos.Remove(gato);
        await context.SaveChangesAsync();
    }

    public async Task<Gato?> RecuperarGatoPorIdAsync(Guid gatoId)
    {
        var gato = await context.Gatos.FirstOrDefaultAsync(g => g.Id == gatoId);
        return gato;
    }

    public async Task AtualizarGatoAsync(Gato gato)
    {
        context.Gatos.Update(gato);
        await context.SaveChangesAsync();
    }

    public async Task<List<Gato>> ListarGatosPorTipoAsync(ECatType tipo)
    {
        var gatoList = context.Gatos
            .Where(x => x.Tipo == tipo)
            .ToList();
        
        return gatoList;
    }

    public async Task AtualizarTipoAsync(Gato gato)
    {
        context.Gatos.Update(gato);
        await context.SaveChangesAsync();
    }
}