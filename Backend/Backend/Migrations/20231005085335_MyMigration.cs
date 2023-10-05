using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Genero = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Tipo = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Status_Sistema = table.Column<bool>(type: "bit", nullable: false),
                    Endereco_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Genero = table.Column<string>(type: "VARCHAR", nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR", nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR", nullable: false),
                    Tipo = table.Column<string>(type: "VARCHAR", nullable: false),
                    Status_Sistema = table.Column<bool>(type: "bit", nullable: false),
                    Endereco_Id = table.Column<int>(type: "int", nullable: false),
                    Matricula = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Empresa = table.Column<string>(type: "VARCHAR", nullable: false),
                    Slogan = table.Column<string>(type: "VARCHAR", nullable: false),
                    Paleta_Cores = table.Column<string>(type: "VARCHAR", nullable: false),
                    Logotipo_URL = table.Column<string>(type: "VARCHAR", nullable: false),
                    Demais_Infos = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    Cidade = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Uf = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: false),
                    Logradouro = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Numero = table.Column<string>(type: "VARCHAR(7)", maxLength: 7, nullable: false),
                    Bairro = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Complemento = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR", nullable: false),
                    Detalhes = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedagogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Genero = table.Column<string>(type: "VARCHAR", nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR", nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR", nullable: false),
                    Tipo = table.Column<string>(type: "VARCHAR", nullable: false),
                    Status_Sistema = table.Column<bool>(type: "bit", nullable: false),
                    Endereco_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedagogos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Genero = table.Column<string>(type: "VARCHAR", nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR", nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR", nullable: false),
                    Tipo = table.Column<string>(type: "VARCHAR", nullable: false),
                    Status_Sistema = table.Column<bool>(type: "bit", nullable: false),
                    Codigo_Registro_Professor = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "VARCHAR", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR", nullable: false),
                    Aluno_Id = table.Column<int>(type: "int", nullable: false),
                    Pedagogo_Id = table.Column<int>(type: "int", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    PedagogoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Pedagogos_PedagogoId",
                        column: x => x.PedagogoId,
                        principalTable: "Pedagogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Materia = table.Column<string>(type: "VARCHAR", nullable: false),
                    Data_Conclusao = table.Column<string>(type: "VARCHAR", nullable: false),
                    Professor_Id = table.Column<int>(type: "int", nullable: false),
                    Aluno_Id = table.Column<int>(type: "int", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercicios_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercicios_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_AlunoId",
                table: "Atendimentos",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_PedagogoId",
                table: "Atendimentos",
                column: "PedagogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_AlunoId",
                table: "Exercicios",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_ProfessorId",
                table: "Exercicios",
                column: "ProfessorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Exercicios");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Pedagogos");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
