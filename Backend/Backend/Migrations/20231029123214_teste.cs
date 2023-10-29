using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    Slogan = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    Paleta_Cores = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Logotipo_URL = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Demais_Infos = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false)
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
                    Tipo = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    Status_Sistema = table.Column<bool>(type: "bit", nullable: false),
                    Matricula_Aluno = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    Codigo_Registro_Professor = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    CEP = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    Cidade = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    UF = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Logradouro = table.Column<string>(type: "VARCHAR(55)", maxLength: 55, nullable: false),
                    Numero = table.Column<string>(type: "VARCHAR(8)", maxLength: 8, nullable: false),
                    Complemento = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Bairro = table.Column<string>(type: "VARCHAR(65)", maxLength: 65, nullable: false),
                    Ponto_Referência = table.Column<string>(type: "VARCHAR(65)", maxLength: 65, nullable: false),
                    Empresa_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Empresas_Empresa_Id",
                        column: x => x.Empresa_Id,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Atendimentos_Usuarios_Pedagogo_Id",
                        column: x => x.Pedagogo_Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Materia = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Data = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Pontuacao_Maxima = table.Column<double>(type: "float", nullable: false),
                    Nota = table.Column<double>(type: "float", nullable: false),
                    Professor_Id = table.Column<int>(type: "int", nullable: false),
                    Aluno_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Usuarios_Aluno_Id",
                        column: x => x.Aluno_Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Titulo = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Materia = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Data_Conclusao = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Exercicios_Usuarios_Professor_Id",
                        column: x => x.Professor_Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false),
                    Acao = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Data = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
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
                table: "Usuarios",
                columns: new[] { "Id", "Bairro", "CEP", "CPF", "Cidade", "Codigo_Registro_Professor", "Complemento", "Email", "Empresa_Id", "Genero", "Logradouro", "Matricula_Aluno", "Nome", "Numero", "Ponto_Referência", "Senha", "Status_Sistema", "Telefone", "Tipo", "UF" },
                values: new object[,]
                {
                    { 1, "Bairro", "88053505", "999.999.999-99", "Floripa", "", "Complemento", "email@gmail.com", 1, "Masculino", "Rua do Senai", "", "ALUNO TESTE", "222", "Teste", "12345678", true, "(99) 9 9999-9999", "Aluno", "SC" },
                    { 2, "Bairro", "88053505", "999.999.999-99", "Floripa", "", "Complemento", "email@gmail.com", 1, "Masculino", "Rua do Senai", "", "PROFESSOR TESTE", "222", "Teste", "12345678", true, "(99) 9 9999-9999", "Professor", "SC" },
                    { 3, "Bairro", "88053505", "999.999.999-99", "Floripa", "", "Complemento", "email@gmail.com", 1, "Masculino", "Rua do Senai", "", "PEDAGOGO TESTE", "222", "Teste", "12345678", true, "(99) 9 9999-9999", "Pedagogo", "SC" },
                    { 4, "Bairro", "88053505", "999.999.999-99", "Floripa", "", "Complemento", "email@gmail.com", 1, "Masculino", "Rua do Senai", "", "ADMINISTRADOR TESTE", "222", "Teste", "12345678", true, "(99) 9 9999-9999", "Administrador", "SC" }
                });

            migrationBuilder.InsertData(
                table: "Atendimentos",
                columns: new[] { "Id", "Aluno_Id", "Data", "Descricao", "Pedagogo_Id" },
                values: new object[] { 1, 1, "10/10/2023", "DESCRICAO EXERCICIO TESTE", 3 });

            migrationBuilder.InsertData(
                table: "Avaliacoes",
                columns: new[] { "Id", "Aluno_Id", "Data", "Descricao", "Materia", "Nota", "Pontuacao_Maxima", "Professor_Id", "Titulo" },
                values: new object[] { 1, 1, "10/10/2023", "DESCRICAO EXERCICIO TESTE", "TESTE", 0.0, 0.0, 2, "EXERCICIO TESTE" });

            migrationBuilder.InsertData(
                table: "Exercicios",
                columns: new[] { "Id", "Aluno_Id", "Data_Conclusao", "Descricao", "Materia", "Professor_Id", "Titulo" },
                values: new object[] { 1, 1, "10/10/2023", "DESCRICAO EXERCICIO TESTE", "TESTE", 2, "EXERCICIO TESTE" });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_Aluno_Id",
                table: "Atendimentos",
                column: "Aluno_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_Pedagogo_Id",
                table: "Atendimentos",
                column: "Pedagogo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_Aluno_Id",
                table: "Avaliacoes",
                column: "Aluno_Id");

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
        }
    }
}
