using System.Net;
using Business.Donos;
using GatoApi.Donos.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GatoApi.Donos;

[ApiController]
[Route("/api/donos")]
public class DonosController(IDonoService donoService) : ControllerBase
{
    /// <summary>
    /// Recupera uma lista com todos os donos.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DonoViewModel>))]
    public async Task<IActionResult> GetAllDonosAsync()
    {
        var donoList = await donoService.GetAllDonosAsync();
        var donoViewModelList = donoList.Select(
            x => new DonoViewModel
            {
                Id = x.Id,
                Nome = x.Nome,
                Email = x.Email,
                Telefone = x.Telefone,
                Cpf = x.Cpf
            }).ToList();
        return Ok(donoViewModelList);
    }

    /// <summary>
    /// Cria um novo dono.
    /// </summary>
    /// <param name="ViewModel"></view model com os dados do novo dono.>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    public async Task<IActionResult> CriarDonoAsync([FromBody] DonoViewModel ViewModel)
    {
        var novoDono =
            await donoService.CriarDonoAsync(ViewModel.Nome, ViewModel.Email, ViewModel.Telefone, ViewModel.Cpf);
        return Ok(novoDono);
    }
    
    /// <summary>
    /// Recupera dono por Id.
    /// </summary>
    /// <param name="Id">Id do dono</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DonoViewModel>))]
    public async Task<IActionResult> GetDonoByIdAsync([FromRoute] Guid Id)
    {
        var donoDto = await donoService.GetDonoByIdAsync(Id);

        if (donoDto.StatusCode == HttpStatusCode.NotFound)
            return NotFound();

        return Ok(donoDto.Dono);
    }

    /// <summary>
    /// Deleta dono da base.
    /// </summary>
    /// <param name="id"></id do dono.>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDonoByIdAsync([FromRoute] Guid id)
    {
        var donoDto = await donoService.DeletarDonoAsync(id);

        if (donoDto.StatusCode == HttpStatusCode.NotFound)
            return NotFound();

        return Ok();
    }

    /// <summary>
    /// Atualiza os dados do dono.
    /// </summary>
    /// <param name="id"></id do dono.>
    /// <param name="viewModel"></view model com os dados do dono.>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDonoByIdAsync([FromRoute] Guid id, [FromBody] UpdateDonoViewModel viewModel)
    {
        var donoDto = new DonoUpdateDto(viewModel.Nome, viewModel.Email, viewModel.Telefone);
        var donoResultDto = await donoService.UpdateDonoByIdAsync(id, donoDto);

        if (donoResultDto.StatusCode == HttpStatusCode.NotFound)
            return NotFound();

        return Ok(donoResultDto.Dono);
    }
}