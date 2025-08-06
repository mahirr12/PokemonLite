using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonLite.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class tbtforabilities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cooldown",
                table: "BaseAbilities");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseAbilities");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "BaseAbilities");

            migrationBuilder.DropColumn(
                name: "Effectiveness",
                table: "BaseAbilities");

            migrationBuilder.DropColumn(
                name: "OpponentEffectiveness",
                table: "BaseAbilities");

            migrationBuilder.DropColumn(
                name: "OwnEffectiveness",
                table: "BaseAbilities");

            migrationBuilder.DropColumn(
                name: "StatusAbilityType",
                table: "BaseAbilities");

            migrationBuilder.DropColumn(
                name: "StatusEffectiveness",
                table: "BaseAbilities");

            migrationBuilder.CreateTable(
                name: "ActiveAbilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Cooldown = table.Column<int>(type: "integer", nullable: false),
                    Effectiveness = table.Column<int[]>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveAbilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveAbilities_BaseAbilities_Id",
                        column: x => x.Id,
                        principalTable: "BaseAbilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassiveAbilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    OwnEffectiveness = table.Column<int[]>(type: "integer[]", nullable: false),
                    OpponentEffectiveness = table.Column<int[]>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassiveAbilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassiveAbilities_BaseAbilities_Id",
                        column: x => x.Id,
                        principalTable: "BaseAbilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusAbilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusEffectiveness = table.Column<int[]>(type: "integer[]", nullable: false),
                    StatusAbilityType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusAbilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusAbilities_BaseAbilities_Id",
                        column: x => x.Id,
                        principalTable: "BaseAbilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveAbilities");

            migrationBuilder.DropTable(
                name: "PassiveAbilities");

            migrationBuilder.DropTable(
                name: "StatusAbilities");

            migrationBuilder.AddColumn<int>(
                name: "Cooldown",
                table: "BaseAbilities",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseAbilities",
                type: "character varying(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "BaseAbilities",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int[]>(
                name: "Effectiveness",
                table: "BaseAbilities",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<int[]>(
                name: "OpponentEffectiveness",
                table: "BaseAbilities",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<int[]>(
                name: "OwnEffectiveness",
                table: "BaseAbilities",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusAbilityType",
                table: "BaseAbilities",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int[]>(
                name: "StatusEffectiveness",
                table: "BaseAbilities",
                type: "integer[]",
                nullable: true);
        }
    }
}
