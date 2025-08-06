using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonLite.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class fixingabilitytrainerpokemonrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseAbilities_TrainerPokemons_TrainerPokemonId",
                table: "BaseAbilities");

            migrationBuilder.DropIndex(
                name: "IX_BaseAbilities_TrainerPokemonId",
                table: "BaseAbilities");

            migrationBuilder.DropColumn(
                name: "TrainerPokemonId",
                table: "BaseAbilities");

            migrationBuilder.CreateTable(
                name: "BaseAbilityTrainerPokemon",
                columns: table => new
                {
                    AbilitiesId = table.Column<Guid>(type: "uuid", nullable: false),
                    PokemonsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseAbilityTrainerPokemon", x => new { x.AbilitiesId, x.PokemonsId });
                    table.ForeignKey(
                        name: "FK_BaseAbilityTrainerPokemon_BaseAbilities_AbilitiesId",
                        column: x => x.AbilitiesId,
                        principalTable: "BaseAbilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseAbilityTrainerPokemon_TrainerPokemons_PokemonsId",
                        column: x => x.PokemonsId,
                        principalTable: "TrainerPokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseAbilityTrainerPokemon_PokemonsId",
                table: "BaseAbilityTrainerPokemon",
                column: "PokemonsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseAbilityTrainerPokemon");

            migrationBuilder.AddColumn<Guid>(
                name: "TrainerPokemonId",
                table: "BaseAbilities",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseAbilities_TrainerPokemonId",
                table: "BaseAbilities",
                column: "TrainerPokemonId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseAbilities_TrainerPokemons_TrainerPokemonId",
                table: "BaseAbilities",
                column: "TrainerPokemonId",
                principalTable: "TrainerPokemons",
                principalColumn: "Id");
        }
    }
}
