using Data.Gatos;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Business.Gatos;

public interface IGatoService
{
    Task<List<Gato>> GetAllGatosAsync();
    Task<Guid> CriarGatoAsync(string nome,ECatType tipo);
    Task<GatoResultDto> DeletarGatoAsync(Guid gatoId);
    Task<GatoResultDto> RecuperarGatoPorIdAsync(Guid gatoId);
    Task<GatoResultDto> AtualizarGatoAsync(Guid id, GatoUpdateDto gatoUpdateDto);
    Task<List<Gato>> ListarGatosPorTipoAsync(ECatType tipo);
    Task<GatoResultDto> AtualizarTipoAsync(Guid id, GatoTypeDto gatoTypeDto);
}