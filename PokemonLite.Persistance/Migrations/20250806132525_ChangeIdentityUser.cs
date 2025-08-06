using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonLite.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonAssignAbilities_BaseAbilities_BaseAbilityId",
                table: "PokemonAssignAbilities");

            migrationBuilder.RenameColumn(
                name: "BaseAbilityId",
                table: "PokemonAssignAbilities",
                newName: "AbilityId");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonAssignAbilities_BaseAbilityId",
                table: "PokemonAssignAbilities",
                newName: "IX_PokemonAssignAbilities_AbilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonAssignAbilities_BaseAbilities_AbilityId",
                table: "PokemonAssignAbilities",
                column: "AbilityId",
                principalTable: "BaseAbilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonAssignAbilities_BaseAbilities_AbilityId",
                table: "PokemonAssignAbilities");

            migrationBuilder.RenameColumn(
                name: "AbilityId",
                table: "PokemonAssignAbilities",
                newName: "BaseAbilityId");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonAssignAbilities_AbilityId",
                table: "PokemonAssignAbilities",
                newName: "IX_PokemonAssignAbilities_BaseAbilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonAssignAbilities_BaseAbilities_BaseAbilityId",
                table: "PokemonAssignAbilities",
                column: "BaseAbilityId",
                principalTable: "BaseAbilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
