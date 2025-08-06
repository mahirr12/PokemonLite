using Microsoft.AspNetCore.Mvc;
using PokemonLite.Contract.DTOs.Specie;
using PokemonLite.Contract.IServices;
using PokemonLite.Domain.Entities;

namespace PokemonLite.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecieController(IGenericService<Specie, CreateSpecieDTO, SpecieDTO> specieService)
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
        if (createSpecieDtOs == null )
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
}