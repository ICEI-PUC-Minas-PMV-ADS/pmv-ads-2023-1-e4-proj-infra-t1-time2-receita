using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_freecipes.Migrations
{
    /// <inheritdoc />
    public partial class V002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etapas_Receitas_ReceitaId",
                table: "Etapas");

            migrationBuilder.DropIndex(
                name: "IX_Etapas_ReceitaId",
                table: "Etapas");

            migrationBuilder.DropColumn(
                name: "ReceitaId",
                table: "Etapas");

            migrationBuilder.CreateTable(
                name: "ReceitaEtapas",
                columns: table => new
                {
                    ReceitaId = table.Column<int>(type: "int", nullable: false),
                    EtapaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceitaEtapas", x => new { x.ReceitaId, x.EtapaId });
                    table.ForeignKey(
                        name: "FK_ReceitaEtapas_Etapas_EtapaId",
                        column: x => x.EtapaId,
                        principalTable: "Etapas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceitaEtapas_Receitas_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaEtapas_EtapaId",
                table: "ReceitaEtapas",
                column: "EtapaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceitaEtapas");

            migrationBuilder.AddColumn<int>(
                name: "ReceitaId",
                table: "Etapas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Etapas_ReceitaId",
                table: "Etapas",
                column: "ReceitaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Etapas_Receitas_ReceitaId",
                table: "Etapas",
                column: "ReceitaId",
                principalTable: "Receitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
