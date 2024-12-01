using Data.Database;

namespace Data.Donos;

public class DonoRepository(AppDbContext context) : IDonoRepository
{
    public async Task <List<Dono>> GetAllDonosAsync()
    {
        var listDonos = context.Donos.ToList();
        return listDonos;
    }

    public async Task CriarDonoAsync(Dono dono)
    {
        await context.Donos.AddAsync(dono);
        await context.SaveChangesAsync();
    }

    public async Task<Dono?> GetDonoByIdAsync(Guid donoId)
    {
        var dono = await context.Donos.FindAsync(donoId);
        return dono;
    }

    public async Task DeletarDonoAsync(Dono dono)
    {
        context.Donos.Remove(dono);
        await context.SaveChangesAsync();
    }

    public async Task UpdateDonoAsync(Dono dono)
    {
        context.Donos.Update(dono);
        await context.SaveChangesAsync();
    }
    
}