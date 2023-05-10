using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF7.API.Migrations
{
    /// <inheritdoc />
    public partial class Nuevamigracion3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEstreno",
                table: "Peliculas",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 15, 3, 16, 366, DateTimeKind.Local).AddTicks(9353),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2023, 5, 10, 14, 56, 56, 429, DateTimeKind.Local).AddTicks(7502));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEstreno",
                table: "Peliculas",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 14, 56, 56, 429, DateTimeKind.Local).AddTicks(7502),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2023, 5, 10, 15, 3, 16, 366, DateTimeKind.Local).AddTicks(9353));
        }
    }
}
