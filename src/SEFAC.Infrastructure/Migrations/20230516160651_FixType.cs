using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEFAC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Duracao",
                table: "Atividade",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Carga_Horaria",
                table: "Atividade",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Duracao",
                table: "Atividade",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Carga_Horaria",
                table: "Atividade",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
