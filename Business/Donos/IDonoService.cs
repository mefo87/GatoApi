using Business.Gatos;
using Data.Donos;

namespace Business.Donos;

public interface IDonoService
{
    Task<List<Dono>> GetAllDonosAsync();
    Task<Guid> CriarDonoAsync (string nome, string email, string telefone, string cpf);
    Task<DonoResultDto> DeletarDonoAsync (Guid donoId);
    Task<DonoResultDto> GetDonoByIdAsync (Guid id);
    Task<DonoResultDto> UpdateDonoByIdAsync (Guid donoId, DonoUpdateDto donoUpdateDto);
}