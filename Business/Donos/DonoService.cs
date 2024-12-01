using System.Net;
using Business.Gatos;
using Data.Donos;

namespace Business.Donos;

public class DonoService(IDonoRepository donoRepository) : IDonoService
{
    public async Task<List<Dono>> GetAllDonosAsync()
    {
        return await donoRepository.GetAllDonosAsync();
    }

    public async Task<DonoResultDto> GetDonoByIdAsync(Guid donoId)
    {
        var dono = await donoRepository.GetDonoByIdAsync(donoId);
        
        if (dono == null)
            return new DonoResultDto(HttpStatusCode.NotFound, null);
            
        return new DonoResultDto(HttpStatusCode.OK, dono);
    }
    
    public async Task<Guid> CriarDonoAsync (string nome, string email, string telefone, string cpf)
    {
        var dono = new Dono(nome, cpf, email, telefone);
        await donoRepository.CriarDonoAsync(dono);
        return dono.Id;
    }

    public async Task<DonoResultDto> DeletarDonoAsync(Guid donoId)
    {
        var dono = await donoRepository.GetDonoByIdAsync(donoId);
        
        if (dono == null)
            return new DonoResultDto(HttpStatusCode.NotFound, null);
        
        await donoRepository.DeletarDonoAsync(dono);
        return new DonoResultDto(HttpStatusCode.OK, null);
    }

    public async Task<DonoResultDto> UpdateDonoByIdAsync(Guid donoId, DonoUpdateDto donoUpdateDto)
    {
        var dono = await donoRepository.GetDonoByIdAsync(donoId);
        
        if (dono == null)
            return new DonoResultDto(HttpStatusCode.NotFound, null);
        
        dono.AtualizarDono(donoUpdateDto.Nome, donoUpdateDto.Email, donoUpdateDto.Telefone);
        await donoRepository.UpdateDonoAsync(dono);
        return new DonoResultDto(HttpStatusCode.OK, dono);
    }
}