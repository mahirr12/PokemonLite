using Microsoft.AspNetCore.Mvc;
using PokemonLite.Contract.DTOs.Pokemon;
using PokemonLite.Contract.IServices;

namespace PokemonLite.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokemonController(
    IPokemonService service)
    : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var data = await service.GetByIdAsync(
            id,
            p=> p.Species);
        if (data == null) return NotFound();
        return Ok(data);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var datas = await service.GetAllAsync(p=> p.Species);
        if ( !datas.Any()) return NotFound("No Pokemons found.");
        return Ok(datas);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreatePokemonDTO createPokemonDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await service.CreateWithSpecieAsync(createPokemonDto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] CreatePokemonDTO updatePokemonDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await service.UpdateWithSpecieAsync(updatePokemonDto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await service.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}