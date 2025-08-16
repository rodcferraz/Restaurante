using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurante.Web.Migrations
{
    /// <inheritdoc />
    public partial class migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Pratos_PratoId",
                table: "Ingredientes");

            migrationBuilder.DropIndex(
                name: "IX_Ingredientes_PratoId",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "PratoId",
                table: "Ingredientes");

            migrationBuilder.CreateTable(
                name: "IngredientePrato",
                columns: table => new
                {
                    IngredientesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PratosId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientePrato", x => new { x.IngredientesId, x.PratosId });
                    table.ForeignKey(
                        name: "FK_IngredientePrato_Ingredientes_IngredientesId",
                        column: x => x.IngredientesId,
                        principalTable: "Ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientePrato_Pratos_PratosId",
                        column: x => x.PratosId,
                        principalTable: "Pratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientePrato_PratosId",
                table: "IngredientePrato",
                column: "PratosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientePrato");

            migrationBuilder.AddColumn<Guid>(
                name: "PratoId",
                table: "Ingredientes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_PratoId",
                table: "Ingredientes",
                column: "PratoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_Pratos_PratoId",
                table: "Ingredientes",
                column: "PratoId",
                principalTable: "Pratos",
                principalColumn: "Id");
        }
    }
}
