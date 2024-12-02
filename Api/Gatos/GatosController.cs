using System.Net;
using Business.Gatos;
using Data.Gatos;
using Microsoft.AspNetCore.Mvc;

namespace GatoApi.Gatos;

[ApiController]
[Route("/api/gatos")]
public class GatosController(IGatoService gatoService) : ControllerBase
{
    /// <summary>
    /// Recupera uma lista com todos os gatos
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Gato>))]
    public async Task<IActionResult> GetAllGatosAsync()
    {
        var gatoList = await gatoService.GetAllGatosAsync();
        var gatoViewModelList = gatoList.Select(
            x => new GatoViewModel
            {
                Id = x.Id,
                Nome = x.Nome,
                Tipo = x.Tipo,
                IdDono = x.IdDono
            }).ToList();
        return Ok(gatoViewModelList);
    }
    
    /// <summary>
    /// Cria um novo gato
    /// </summary>
    /// <param name="viewModel">ViewModel com os dados do novo gato</param>
    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    public async Task<IActionResult> AddGatosAsync([FromBody] CriarGatoViewModel viewModel)
    {
        var gatoID = await gatoService.CriarGatoAsync(viewModel.Nome, viewModel.Tipo, viewModel.IdDono);
        return Ok(gatoID);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Gato))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetGatosByIdAsync([FromRoute] Guid id)
    {
        var gatoDto = await gatoService.RecuperarGatoPorIdAsync(id);
        if (gatoDto.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound();
        }
        return Ok(gatoDto.Gato);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGatosAsync([FromRoute] Guid id)
    {
        var gatoDto = await gatoService.DeletarGatoAsync(id);
        
        if (gatoDto.StatusCode == HttpStatusCode.NotFound)
            return NotFound();
        
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizeGatosAsync([FromRoute] Guid id,[FromBody] UpdateGatoViewModel viewModel )
    {
        var gatoDto = new GatoUpdateDto(viewModel.Nome, viewModel.Tipo);
        var gatoResultDto = await gatoService.AtualizarGatoAsync(id, gatoDto);
        
        if (gatoResultDto.StatusCode == HttpStatusCode.NotFound)
            return NotFound();

        return Ok(gatoResultDto.Gato);
    }

    [HttpGet("PorTipo")]
    public async Task<IActionResult> ListarGatosPorTipoAsync([FromQuery] ECatType tipo)
    {
        var gatoList = await gatoService.ListarGatosPorTipoAsync(tipo);
        var gatoViewModelList = gatoList.Select(
            x => new GatoViewModel
            {
                Id = x.Id,
                Nome = x.Nome,
                Tipo = x.Tipo,
                IdDono = x.IdDono
            }).ToList();
        return Ok(gatoViewModelList);
    }

    [HttpPatch("{id}/Tipo")]
    public async Task<IActionResult> AtualizarTipoAsync([FromRoute] Guid id, [FromBody] TrocarTipoViewModel viewModel)
    {
        var gatoDto = new GatoTypeDto(viewModel.Tipo);
        var gatoResultDto = await gatoService.AtualizarTipoAsync(id, gatoDto);
        if (gatoResultDto.StatusCode == HttpStatusCode.NotFound)
            return NotFound();
        
        return Ok(gatoResultDto.Gato);
    }
}