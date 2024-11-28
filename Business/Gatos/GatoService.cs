using System.Net;
using Data.Gatos;

namespace Business.Gatos;

public class GatoService(IGatoRepository gatoRepository) : IGatoService
{
    public async Task<List<Gato>> GetAllGatosAsync()
    {
        return await gatoRepository.GetAllGatosAsync();
    }

    public async Task<Guid> CriarGatoAsync(string nome, ECatType tipo)
    {
        var gato = new Gato(nome, tipo);
        await gatoRepository.CriarGatoAsync(gato);
        return gato.Id;
    }

    public async Task<GatoResultDto> DeletarGatoAsync(Guid id)
    {
        var gato = await gatoRepository.RecuperarGatoPorIdAsync(id);
        if (gato == null)
        
            return new GatoResultDto(HttpStatusCode.NotFound, null);
        
        await gatoRepository.DeletarGatoAsync(gato);
        return new GatoResultDto(HttpStatusCode.OK, null);
    }

    public async Task<GatoResultDto> RecuperarGatoPorIdAsync(Guid gatoId)
    {
        var gato = await gatoRepository.RecuperarGatoPorIdAsync(gatoId);
        if (gato == null)
        
            return new GatoResultDto(HttpStatusCode.NotFound, null);
        
        return new GatoResultDto(HttpStatusCode.OK, gato);
    }
    
    public async Task<GatoResultDto> AtualizarGatoAsync(Guid id, GatoUpdateDto gatoUpdateDto)
    {
        var gato = await gatoRepository.RecuperarGatoPorIdAsync(id);
        if (gato == null)
        
            return new GatoResultDto(HttpStatusCode.NotFound, null);
        

        gato.AtualizarGato(gatoUpdateDto.Nome, gatoUpdateDto.Tipo);
        await gatoRepository.AtualizarGatoAsync(gato);
        return new GatoResultDto(HttpStatusCode.OK, gato);
    }

    public async Task<List<Gato>> ListarGatosPorTipoAsync(ECatType tipo)
    {
        return await gatoRepository.ListarGatosPorTipoAsync(tipo);
    }

    public async Task<GatoResultDto> AtualizarTipoAsync(Guid id, GatoTypeDto gatoTypeDto)
    {
        var gato = await gatoRepository.RecuperarGatoPorIdAsync(id);
        
        if (gato == null)
            return new GatoResultDto(HttpStatusCode.NotFound, null);
        
        gato.AtualizarTipo(gatoTypeDto.Tipo);
        await gatoRepository.AtualizarTipoAsync(gato);
        return new GatoResultDto(HttpStatusCode.OK, gato);
    }
}