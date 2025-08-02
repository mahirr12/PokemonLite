using Microsoft.AspNetCore.Identity;

namespace PokemonLite.Domain.Entities;

public class User : IdentityUser
{
    public DateTime CreatedTime { get; set; } = DateTime.UtcNow.AddHours(4);
    public DateTime? UpdatedTime { get; set; } = DateTime.UtcNow.AddHours(4);
    public bool IsDeleted { get; set; }

   
}