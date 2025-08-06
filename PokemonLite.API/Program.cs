using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PokemonLite.Application.MapperProfiles;
using PokemonLite.Application.Services;
using PokemonLite.Contract.IServices;
using PokemonLite.Domain.IRepositories;
using PokemonLite.Persistance.DataBase;
using PokemonLite.Persistance.Implementations;
using PokemonLite.Persistance.Repositories;
using PokemonLite.Persistance.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Entity Framework Core with PostgreSQL
builder.Services.AddDbContext<PokemonDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Identity
builder.Services.AddIdentity<User, IdentityRole>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedAccount = false;
        }
    )
    .AddEntityFrameworkStores<PokemonDBContext>()
    .AddDefaultTokenProviders();

// Add services to the container for dependency injection.
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<,,>), typeof(GenericService<,,>));
builder.Services.AddScoped<IAbilityService, AbilityService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//automapper
builder.Services.AddAutoMapper(cfg => { cfg.AddProfile(new CustomProfile()); });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Seed the database with initial roles
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await IdentitySeed.SeedRolesAsync(services);
}

app.Run();