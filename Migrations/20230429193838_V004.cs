using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_freecipes.Migrations
{
    /// <inheritdoc />
    public partial class V004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
