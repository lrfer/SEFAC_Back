using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEFAC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Correcaorelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecucaoAtividade_Aluno_AlunoId",
                table: "ExecucaoAtividade");

            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "ExecucaoAtividade",
                newName: "IdAluno");

            migrationBuilder.RenameIndex(
                name: "IX_ExecucaoAtividade_AlunoId",
                table: "ExecucaoAtividade",
                newName: "IX_ExecucaoAtividade_IdAluno");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecucaoAtividade_Aluno_IdAluno",
                table: "ExecucaoAtividade",
                column: "IdAluno",
                principalTable: "Aluno",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecucaoAtividade_Aluno_IdAluno",
                table: "ExecucaoAtividade");

            migrationBuilder.RenameColumn(
                name: "IdAluno",
                table: "ExecucaoAtividade",
                newName: "AlunoId");

            migrationBuilder.RenameIndex(
                name: "IX_ExecucaoAtividade_IdAluno",
                table: "ExecucaoAtividade",
                newName: "IX_ExecucaoAtividade_AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecucaoAtividade_Aluno_AlunoId",
                table: "ExecucaoAtividade",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
