using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonLite.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addbattle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseAttackSpeed",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "BaseDefenseSpeed",
                table: "Pokemons");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "TrainerPokemons",
                newName: "Exp");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentHp",
                table: "TrainerPokemons",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<int>(
                name: "CurrentAttack",
                table: "TrainerPokemons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentDefense",
                table: "TrainerPokemons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "BaseHp",
                table: "Pokemons",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    JoinerId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battles_Trainers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Battles_Trainers_JoinerId",
                        column: x => x.JoinerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BattleTrainerPokemon",
                columns: table => new
                {
                    BattleId = table.Column<Guid>(type: "uuid", nullable: false),
                    TrainerPokemonId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsCreatorPokemon = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleTrainerPokemon", x => new { x.BattleId, x.TrainerPokemonId });
                    table.ForeignKey(
                        name: "FK_BattleTrainerPokemon_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleTrainerPokemon_TrainerPokemons_TrainerPokemonId",
                        column: x => x.TrainerPokemonId,
                        principalTable: "TrainerPokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Battles_CreatorId",
                table: "Battles",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_JoinerId",
                table: "Battles",
                column: "JoinerId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleTrainerPokemon_TrainerPokemonId",
                table: "BattleTrainerPokemon",
                column: "TrainerPokemonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleTrainerPokemon");

            migrationBuilder.DropTable(
                name: "Battles");

            migrationBuilder.DropColumn(
                name: "CurrentAttack",
                table: "TrainerPokemons");

            migrationBuilder.DropColumn(
                name: "CurrentDefense",
                table: "TrainerPokemons");

            migrationBuilder.RenameColumn(
                name: "Exp",
                table: "TrainerPokemons",
                newName: "Order");

            migrationBuilder.AlterColumn<double>(
                name: "CurrentHp",
                table: "TrainerPokemons",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "BaseHp",
                table: "Pokemons",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "BaseAttackSpeed",
                table: "Pokemons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseDefenseSpeed",
                table: "Pokemons",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
