using Microsoft.AspNetCore.Mvc;
using PokemonLite.Contract.DTOs.Trainer;
using PokemonLite.Contract.IServices;
using PokemonLite.Domain.Entities;

namespace PokemonLite.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrainerController(
    IGenericService<Trainer,CreateTrainerDTO,TrainerDTO> service)
    : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var data = await service.GetByIdAsync(id);
        if (data == null)
            return NotFound();
        return Ok(data);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var datas = await service.GetAllAsync();
        if (!datas.Any())
            return NotFound("No Trainers found.");
        return Ok(datas);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateTrainerDTO createTrainerDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await service.CreateAsync(createTrainerDto);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] CreateTrainerDTO updateTrainerDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await service.UpdateAsync(updateTrainerDto);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await service.DeleteAsync(id);
        if (!result)
            return NotFound();
        return NoContent();
    }
}