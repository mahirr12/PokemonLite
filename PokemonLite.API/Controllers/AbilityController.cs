using Microsoft.AspNetCore.Mvc;
using PokemonLite.Contract.DTOs.Ability;
using PokemonLite.Contract.IServices;

namespace PokemonLite.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AbilityController(
    IAbilityService abilityService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var ability = await abilityService.GetByIdAsync(id);
        if (ability == null) return NotFound();
        return Ok(ability);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var abilities = await abilityService.GetAllAsync();
        return Ok(abilities);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateAbilityDTO createAbilityDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await abilityService.CreateAsync(createAbilityDto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] CreateAbilityDTO updateAbilityDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await abilityService.UpdateAsync(updateAbilityDto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await abilityService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }

    // Action for adding multiple abilities
    [HttpPost("bulk")]
    public async Task<IActionResult> CreateMultipleAsync([FromBody] IEnumerable<CreateAbilityDTO>? createAbilityDtos)
    {
        if (createAbilityDtos == null)
            return BadRequest("No abilities provided for creation.");
        var results = new List<AbilityDTO>();
        foreach (var createAbilityDto in createAbilityDtos)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await abilityService.CreateAsync(createAbilityDto);
            results.Add(result);
        }

        return Ok(results);
    }
}