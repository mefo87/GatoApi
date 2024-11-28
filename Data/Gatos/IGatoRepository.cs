namespace Data.Gatos;

public interface IGatoRepository
{
    Task<List<Gato>> GetAllGatosAsync();
    Task CriarGatoAsync(Gato gato);
    Task DeletarGatoAsync(Gato gato);
    Task<Gato?> RecuperarGatoPorIdAsync(Guid gatoId);
    Task AtualizarGatoAsync(Gato gato);
    Task<List<Gato>> ListarGatosPorTipoAsync(ECatType tipo);
    Task AtualizarTipoAsync(Gato gato);
}