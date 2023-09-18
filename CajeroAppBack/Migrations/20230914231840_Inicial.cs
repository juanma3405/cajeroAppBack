using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CajeroAppBack.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarjetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroTarjeta = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Pin = table.Column<int>(type: "int", nullable: false),
                    Bloqueada = table.Column<bool>(type: "bit", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjetas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTarjeta = table.Column<int>(type: "int", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantidadRetirada = table.Column<double>(type: "float", nullable: false),
                    TarjetaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operaciones_Tarjetas_TarjetaId",
                        column: x => x.TarjetaId,
                        principalTable: "Tarjetas",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Tarjetas",
                columns: new[] { "Id", "Balance", "Bloqueada", "FechaVencimiento", "NumeroTarjeta", "Pin" },
                values: new object[,]
                {
                    { 1, 0.0, false, new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "1001100110011001", 1212 },
                    { 2, 0.0, false, new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "1002100210021002", 1515 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_TarjetaId",
                table: "Operaciones",
                column: "TarjetaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operaciones");

            migrationBuilder.DropTable(
                name: "Tarjetas");
        }
    }
}
