using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEFAC.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nr_Matricula = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cod_Curso = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atividade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dt_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dt_Fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Carga_Horaria = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdAluno = table.Column<int>(type: "int", nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atividade");

            migrationBuilder.DropTable(
                name: "Aluno");
        }
    }
}
