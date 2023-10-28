using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
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
                    Nome_Empresa = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Slogan = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Paleta_Cores = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Logotipo_URL = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Demais_Infos = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
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
                    Localidade = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    UF = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Logradouro = table.Column<string>(type: "VARCHAR(55)", maxLength: 55, nullable: false),
                    Numero = table.Column<string>(type: "VARCHAR(8)", maxLength: 8, nullable: false),
                    Complemento = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true),
                    Bairro = table.Column<string>(type: "VARCHAR(65)", maxLength: 65, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Tipo = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Genero = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(16)", maxLength: 16, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Tipo = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Status_Sistema = table.Column<bool>(type: "bit", nullable: false),
                    Matricula_Aluno = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: true),
                    Codigo_Registro_Professor = table.Column<int>(type: "int", nullable: true),
                    Empresa_Id = table.Column<int>(type: "int", nullable: false),
                    Endereco_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Empresas_Empresa_Id",
                        column: x => x.Empresa_Id,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuarios_Enderecos_Endereco_Id",
                        column: x => x.Endereco_Id,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Pedagogo_Id = table.Column<int>(type: "int", nullable: false)
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
                name: "Avaliacoes",
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
                    Professor_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Usuarios_Professor_Id",
                        column: x => x.Professor_Id,
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
                    Aluno_Id = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Acao = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Detalhes = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Usuarios_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "Id", "Demais_Infos", "Logotipo_URL", "Nome_Empresa", "Paleta_Cores", "Slogan" },
                values: new object[] { 1, "Silicon Island", "wwww.Success.com", "Sucesso Total", "RGB", "Vitória" });

            migrationBuilder.InsertData(
                table: "Enderecos",
                columns: new[] { "Id", "Bairro", "CEP", "Complemento", "Localidade", "Logradouro", "Numero", "UF" },
                values: new object[] { 1, "Lagoon", "88062015", "Centrinho", "Floripa", "Nsa Senhora", "3432", "SC" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CPF", "Codigo_Registro_Professor", "Email", "Empresa_Id", "Endereco_Id", "Genero", "Matricula_Aluno", "Nome", "Senha", "Status_Sistema", "Telefone", "Tipo" },
                values: new object[] { 1, "111.222.333-23", null, "admin@gmail.com", 1, 1, "Masculino", null, "Admin Supremo", "12345", true, "(48) 9 8873-5467", "Administrador" });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_Aluno_Id",
                table: "Atendimentos",
                column: "Aluno_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_Pedagogo_Id",
                table: "Atendimentos",
                column: "Pedagogo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_Professor_Id",
                table: "Avaliacoes",
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
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "Exercicios");

            migrationBuilder.DropTable(
                name: "Logins");

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
