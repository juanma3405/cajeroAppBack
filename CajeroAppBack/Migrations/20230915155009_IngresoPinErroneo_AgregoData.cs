using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CajeroAppBack.Migrations
{
    /// <inheritdoc />
    public partial class IngresoPinErroneo_AgregoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IngresoPinErroneo",
                table: "Tarjetas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Tarjetas",
                keyColumn: "Id",
                keyValue: 1,
                column: "IngresoPinErroneo",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tarjetas",
                keyColumn: "Id",
                keyValue: 2,
                column: "IngresoPinErroneo",
                value: 0);

            migrationBuilder.InsertData(
                table: "Tarjetas",
                columns: new[] { "Id", "Balance", "Bloqueada", "FechaVencimiento", "IngresoPinErroneo", "NumeroTarjeta", "Pin" },
                values: new object[,]
                {
                    { 3, 15000.0, false, new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "1003100310031003", 1616 },
                    { 4, 5000.0, false, new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "1004100410041004", 1717 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarjetas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tarjetas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "IngresoPinErroneo",
                table: "Tarjetas");
        }
    }
}
