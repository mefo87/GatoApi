namespace Data.Donos;

public interface IDonoRepository
{
    Task<List<Dono>> GetAllDonosAsync();
    Task CriarDonoAsync(Dono dono);
    Task<Dono?> GetDonoByIdAsync(Guid donoId);
    Task DeletarDonoAsync(Dono dono);
    
    Task UpdateDonoAsync(Dono dono);
    
}