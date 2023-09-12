using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SEFAC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nr_Matricula = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Cod_Curso = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atividade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Dt_Inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Dt_Fim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Carga_Horaria = table.Column<decimal>(type: "numeric", nullable: false),
                    Duracao = table.Column<decimal>(type: "numeric", nullable: false),
                    IdAluno = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atividade_Aluno_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Aluno",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Nr_Matricula",
                table: "Aluno",
                column: "Nr_Matricula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atividade_IdAluno",
                table: "Atividade",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atividade");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Aluno");
        }
    }
}
