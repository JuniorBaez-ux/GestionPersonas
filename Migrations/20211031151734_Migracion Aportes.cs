using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionPersonas.Migrations
{
    public partial class MigracionAportes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aportes",
                columns: table => new
                {
                    AporteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Concepto = table.Column<string>(type: "TEXT", nullable: true),
                    Monto = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aportes", x => x.AporteId);
                });

            migrationBuilder.CreateTable(
                name: "tipoAportes",
                columns: table => new
                {
                    TipoAporteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoAportes", x => x.TipoAporteId);
                });

            migrationBuilder.CreateTable(
                name: "AportesDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AporteId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoAportesId = table.Column<int>(type: "INTEGER", nullable: false),
                    Monto = table.Column<double>(type: "REAL", nullable: false),
                    Total = table.Column<double>(type: "REAL", nullable: false),
                    MontoDeseado = table.Column<double>(type: "REAL", nullable: false),
                    TipoAporteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AportesDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AportesDetalle_Aportes_TipoAporteId",
                        column: x => x.TipoAporteId,
                        principalTable: "Aportes",
                        principalColumn: "AporteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AportesDetalle_TipoAporteId",
                table: "AportesDetalle",
                column: "TipoAporteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AportesDetalle");

            migrationBuilder.DropTable(
                name: "tipoAportes");

            migrationBuilder.DropTable(
                name: "Aportes");
        }
    }
}
