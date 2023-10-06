using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    CEP = table.Column<string>(type: "VARCHAR", nullable: false),
                    Cidade = table.Column<string>(type: "VARCHAR", nullable: false),
                    Estado = table.Column<string>(type: "VARCHAR", nullable: false),
                    Logradouro = table.Column<string>(type: "VARCHAR", nullable: false),
                    Numero = table.Column<string>(type: "VARCHAR", nullable: false),
                    Complemento = table.Column<string>(type: "VARCHAR", nullable: false),
                    Bairro = table.Column<string>(type: "VARCHAR", nullable: false),
                    Ponto_Referencia = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
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
                    Matricula_Aluno = table.Column<string>(type: "VARCHAR", nullable: false),
                    Codigo_Registro_Professor = table.Column<string>(type: "VARCHAR", nullable: false),
                    Empresa_Id = table.Column<int>(type: "int", nullable: false),
                    Endereco_Id = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Enderecos_Endereco_Id",
                        column: x => x.Endereco_Id,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(8)", maxLength: 8, nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    Materia = table.Column<string>(type: "VARCHAR", nullable: false),
                    Data = table.Column<string>(type: "VARCHAR", nullable: false),
                    Pontuacao_Maxima = table.Column<double>(type: "float", nullable: false),
                    Nota = table.Column<double>(type: "float", nullable: false),
                    Professor_Id = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Usuarios_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Usuarios",
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
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercicios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false),
                    Acao = table.Column<string>(type: "VARCHAR", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Detalhes = table.Column<string>(type: "VARCHAR", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_UsuarioId",
                table: "Atendimentos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_ProfessorId",
                table: "Avaliacao",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_UsuarioId",
                table: "Exercicios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UsuarioId",
                table: "Logs",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EmpresaId",
                table: "Usuarios",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Endereco_Id",
                table: "Usuarios",
                column: "Endereco_Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Exercicios");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
