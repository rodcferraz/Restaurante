using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurante.Web.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Prato_ReceitaId",
                table: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Prato");

            migrationBuilder.DropIndex(
                name: "IX_Ingredientes_ReceitaId",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "ReceitaId",
                table: "Ingredientes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceitaId",
                table: "Ingredientes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Prato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prato", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_ReceitaId",
                table: "Ingredientes",
                column: "ReceitaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_Prato_ReceitaId",
                table: "Ingredientes",
                column: "ReceitaId",
                principalTable: "Prato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
