using Microsoft.AspNetCore.Mvc;
using PokemonLite.Contract.DTOs.Specie;
using PokemonLite.Contract.DTOs.SpecieEffectiveness;
using PokemonLite.Contract.IServices;
using PokemonLite.Domain.Entities;

namespace PokemonLite.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecieController(
    IGenericService<Specie, CreateSpecieDTO, SpecieDTO> specieService,
    ISpecieEffectivenessService seService)
    : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var specie = await specieService.GetByIdAsync(id);
        if (specie == null) return NotFound();
        return Ok(specie);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var species = await specieService.GetAllAsync();
        return Ok(species);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateSpecieDTO createSpecieDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await specieService.CreateAsync(createSpecieDto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] CreateSpecieDTO updateSpecieDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await specieService.UpdateAsync(updateSpecieDto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await specieService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }

    //action for adding multiple species
    [HttpPost("bulk")]
    public async Task<IActionResult> CreateMultipleAsync([FromBody] IEnumerable<CreateSpecieDTO>? createSpecieDtOs)
    {
        if (createSpecieDtOs == null)
            return BadRequest("No species provided for creation.");
        var results = new List<SpecieDTO>();
        foreach (var createSpecieDto in createSpecieDtOs)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await specieService.CreateAsync(createSpecieDto);
            results.Add(result);
        }

        return Ok(results);
    }

    // set specieeffectiveness
    [HttpPost("effectiveness")]
    public async Task<IActionResult> SetSpecieEffectivenessAsync(
        [FromBody] CreateSpecieEffectivenessDTO createSpecieEffectivenessDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await seService.CreateAsync(createSpecieEffectivenessDto);
        return Ok(result);
    }

    // get specieeffectiveness by id
    [HttpGet("effectiveness/{aId}/{dId}")]
    public async Task<IActionResult> GetSpecieEffectivenessByIdAsync(Guid aId, Guid dId)
    {
        var effectiveness = await seService.GetByIdAsync(aId, dId);
        if (effectiveness == null) return NotFound();
        return Ok(effectiveness);
    }

    // get all specieeffectiveness
    [HttpGet("effectiveness")]
    public async Task<IActionResult> GetAllSpecieEffectivenessAsync()
    {
        var effectivenessList = await seService.GetAllAsync();
        return Ok(effectivenessList);
    }

    //get all effectiveness by specie id
    [HttpGet("effectiveness/specie/{specieId}")]
    public async Task<IActionResult> GetAllEffectivenessBySpecieIdAsync(Guid specieId)
    {
        var effectivenessList = await seService.GetAllBySpecieAsync(specieId);
        if (effectivenessList == null || !effectivenessList.Any())
            return NotFound("No effectiveness found for the specified specie.");
        return Ok(effectivenessList);
    }

    // update specieeffectiveness
    [HttpPut("effectiveness")]
    public async Task<IActionResult> UpdateSpecieEffectivenessAsync(
        [FromBody] CreateSpecieEffectivenessDTO updateSpecieEffectivenessDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await seService.UpdateAsync(updateSpecieEffectivenessDto);
        return Ok(result);
    }

    // delete specieeffectiveness
    [HttpDelete("effectiveness/{aId}/{dId}")]
    public async Task<IActionResult> DeleteSpecieEffectivenessAsync(Guid aId, Guid dId)
    {
        var result = await seService.DeleteAsync(aId, dId);
        if (!result) return NotFound();
        return NoContent();
    }
}