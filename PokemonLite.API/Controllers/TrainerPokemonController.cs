using Microsoft.AspNetCore.Mvc;
using PokemonLite.Contract.DTOs.TrainerPokemon;
using PokemonLite.Contract.IServices;

namespace PokemonLite.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrainerPokemonController(
    ITrainerPokemonService trainerPokemonService
)
    : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var data = await trainerPokemonService.GetByIdAsync(id,
            tp => tp.Trainer,
            tp => tp.Pokemon);
        if (data == null)
            return NotFound();
        return Ok(data);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var datas = await trainerPokemonService.GetAllAsync(
            tp => tp.Trainer,
            tp => tp.Pokemon);
        if (!datas.Any())
            return NotFound("No TrainerPokemons found.");
        return Ok(datas);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateTrainerPokemonDTO createTrainerPokemonDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await trainerPokemonService.CreateWithRandomStatsAsync(createTrainerPokemonDto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] CreateTrainerPokemonDTO updateTrainerPokemonDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await trainerPokemonService.UpdateAsync(updateTrainerPokemonDto);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await trainerPokemonService.DeleteAsync(id);
        if (!result)
            return NotFound();
        return NoContent();
    }
}