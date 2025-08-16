using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurante.Web.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PratoId",
                table: "Ingredientes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pratos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pratos", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Pratos_PratoId",
                table: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Pratos");

            migrationBuilder.DropIndex(
                name: "IX_Ingredientes_PratoId",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "PratoId",
                table: "Ingredientes");
        }
    }
}
