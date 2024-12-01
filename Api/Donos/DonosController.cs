using System.Net;
using Business.Donos;
using Data.Donos;
using GatoApi.Donos.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GatoApi.Donos;

[ApiController]
[Route("/api/donos")]
public class DonosController(IDonoService donoService) : ControllerBase
{
    [HttpGet]
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

    [HttpPost]
    public async Task<IActionResult> CriarDonoAsync([FromBody] DonoViewModel ViewModel)
    {
        var novoDono =
            await donoService.CriarDonoAsync(ViewModel.Nome, ViewModel.Email, ViewModel.Telefone, ViewModel.Cpf);
        return Ok(novoDono);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDonoByIdAsync([FromRoute]Guid Id)
    {
        var donoDto  = await donoService.GetDonoByIdAsync(Id);
        
        if (donoDto.StatusCode == HttpStatusCode.NotFound)
            return NotFound();
        
        return Ok(donoDto.Dono);
    }

    /// <summary>
    /// Deleta dono da base
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDonoByIdAsync([FromRoute] Guid id)
    {
        var donoDto = await donoService.DeletarDonoAsync(id);

        if (donoDto.StatusCode == HttpStatusCode.NotFound)
            return NotFound();

        return Ok();
    }

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