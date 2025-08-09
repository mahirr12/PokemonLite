using Microsoft.AspNetCore.Mvc;
using PokemonLite.Contract.DTOs.Battle;
using PokemonLite.Contract.IServices;

namespace PokemonLite.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BattleController(
    IBattleService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateBattle([FromBody] CreateBattleDTO createBattleDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await service.CreateBattleAsync(createBattleDto);
        return Ok(result);
    }

    [HttpPut("join")]
    public async Task<IActionResult> JoinBattle([FromBody] JoinBattleDTO joinBattleDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await service.JoinBattleAsync(joinBattleDto);
        return Ok(result);
    }
    
    
}