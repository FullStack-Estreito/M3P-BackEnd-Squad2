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
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome_Empresa = table.Column<string>(type: "VARCHAR", nullable: false),
                    Slogan = table.Column<string>(type: "VARCHAR", nullable: false),
                    Paleta_Cores = table.Column<string>(type: "VARCHAR", nullable: false),
                    Logotipo_URL = table.Column<string>(type: "VARCHAR", nullable: false),
                    Demais_Infos = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "VARCHAR", maxLength: 64, nullable: false),
                    Genero = table.Column<string>(type: "VARCHAR", nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR", nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR", nullable: false),
                    Tipo = table.Column<string>(type: "VARCHAR", nullable: false),
                    Status_Sistema = table.Column<bool>(type: "INTEGER", nullable: false),
                    Matricula_Aluno = table.Column<string>(type: "VARCHAR", nullable: false),
                    Codigo_Registro_Professor = table.Column<string>(type: "VARCHAR", nullable: false),
                    Empresa_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Endereco_Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Empresa_Empresa_Id",
                        column: x => x.Empresa_Id,
                        principalTable: "Empresa",
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data = table.Column<string>(type: "VARCHAR", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR", nullable: false),
                    Aluno_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Pedagogo_Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Usuarios_Aluno_Id",
                        column: x => x.Aluno_Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Usuarios_Pedagogo_Id",
                        column: x => x.Pedagogo_Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "VARCHAR", maxLength: 8, nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR", maxLength: 15, nullable: false),
                    Materia = table.Column<string>(type: "VARCHAR", nullable: false),
                    Data = table.Column<string>(type: "VARCHAR", nullable: false),
                    Pontuacao_Maxima = table.Column<double>(type: "REAL", nullable: false),
                    Nota = table.Column<double>(type: "REAL", nullable: false),
                    Professor_Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Usuarios_Professor_Id",
                        column: x => x.Professor_Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "VARCHAR", maxLength: 64, nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false),
                    Materia = table.Column<string>(type: "VARCHAR", nullable: false),
                    Data_Conclusao = table.Column<string>(type: "VARCHAR", nullable: false),
                    Professor_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Aluno_Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercicios_Usuarios_Aluno_Id",
                        column: x => x.Aluno_Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercicios_Usuarios_Professor_Id",
                        column: x => x.Professor_Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Usuario_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Acao = table.Column<string>(type: "VARCHAR", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Detalhes = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Usuarios_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_Aluno_Id",
                table: "Atendimentos",
                column: "Aluno_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_Pedagogo_Id",
                table: "Atendimentos",
                column: "Pedagogo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_Professor_Id",
                table: "Avaliacao",
                column: "Professor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_Aluno_Id",
                table: "Exercicios",
                column: "Aluno_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_Professor_Id",
                table: "Exercicios",
                column: "Professor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_Usuario_Id",
                table: "Logs",
                column: "Usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Empresa_Id",
                table: "Usuarios",
                column: "Empresa_Id");

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
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
