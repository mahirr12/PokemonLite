using PokemonLite.Domain.Entities;

namespace PokemonLite.Domain.Contracts;

public interface IUser
{
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    
    public bool IsDeleted { get; set; }
    public Trainer? Trainer { get; set; }
}