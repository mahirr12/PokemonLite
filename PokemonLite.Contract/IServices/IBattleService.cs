using PokemonLite.Contract.DTOs.Battle;
using PokemonLite.Domain.Entities;

namespace PokemonLite.Contract.IServices;

public interface IBattleService:IGenericService<Battle,CreateBattleDTO, BattleDTO>
{
    Task<BattleDTO> CreateBattleAsync(CreateBattleDTO dto);
    Task<BattleDTO> JoinBattleAsync(JoinBattleDTO dto);
    Task<BattleDTO> SelectMoveAsync();
}