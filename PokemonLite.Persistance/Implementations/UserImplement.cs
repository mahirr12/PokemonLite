using Microsoft.AspNetCore.Identity;
using PokemonLite.Domain.Contracts;
using PokemonLite.Domain.Entities;

namespace PokemonLite.Persistance.Implementations;

public class User:IdentityUser, IUser
{
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public bool IsDeleted { get; set; }
    public Trainer? Trainer { get; set; }
}