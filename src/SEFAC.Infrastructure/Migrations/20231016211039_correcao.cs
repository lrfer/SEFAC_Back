using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SEFAC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class correcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atividade_Aluno_IdAluno",
                table: "Atividade");

            migrationBuilder.DropIndex(
                name: "IX_Atividade_IdAluno",
                table: "Atividade");

            migrationBuilder.DropColumn(
                name: "Carga_Horaria",
                table: "Atividade");

            migrationBuilder.DropColumn(
                name: "Dt_Fim",
                table: "Atividade");

            migrationBuilder.DropColumn(
                name: "Dt_Inicio",
                table: "Atividade");

            migrationBuilder.DropColumn(
                name: "Duracao",
                table: "Atividade");

            migrationBuilder.DropColumn(
                name: "IdAluno",
                table: "Atividade");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Atividade",
                newName: "Descricao");

            migrationBuilder.AddColumn<string>(
                name: "Anexo",
                table: "Atividade",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cd_siex",
                table: "Atividade",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ExecucaoAtividade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Dt_Inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Dt_Fim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Carga_Horaria = table.Column<decimal>(type: "numeric", nullable: false),
                    Duracao = table.Column<decimal>(type: "numeric", nullable: false),
                    IdAtividade = table.Column<int>(type: "integer", nullable: false),
                    AlunoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecucaoAtividade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExecucaoAtividade_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExecucaoAtividade_Atividade_IdAtividade",
                        column: x => x.IdAtividade,
                        principalTable: "Atividade",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExecucaoAtividade_AlunoId",
                table: "ExecucaoAtividade",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecucaoAtividade_IdAtividade",
                table: "ExecucaoAtividade",
                column: "IdAtividade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExecucaoAtividade");

            migrationBuilder.DropColumn(
                name: "Anexo",
                table: "Atividade");

            migrationBuilder.DropColumn(
                name: "Cd_siex",
                table: "Atividade");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Atividade",
                newName: "Nome");

            migrationBuilder.AddColumn<decimal>(
                name: "Carga_Horaria",
                table: "Atividade",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dt_Fim",
                table: "Atividade",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Dt_Inicio",
                table: "Atividade",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Duracao",
                table: "Atividade",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "IdAluno",
                table: "Atividade",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Atividade_IdAluno",
                table: "Atividade",
                column: "IdAluno");

            migrationBuilder.AddForeignKey(
                name: "FK_Atividade_Aluno_IdAluno",
                table: "Atividade",
                column: "IdAluno",
                principalTable: "Aluno",
                principalColumn: "Id");
        }
    }
}
