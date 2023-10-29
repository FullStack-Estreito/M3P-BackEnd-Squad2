using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{
    public class LabSchoolContext : DbContext
    {
        public LabSchoolContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Empresa>().HasData(
                new Empresa
                {
                    Id = 1,
                    Nome_Empresa = "Sucesso Total",
                    Slogan = "Vitória",
                    Paleta_Cores = "RGB",
                    Logotipo_URL = "wwww.Success.com",
                    Demais_Infos = "Silicon Island"
                }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nome = "ALUNO TESTE",
                    Genero = "Masculino",
                    CPF = "999.999.999-99",
                    Telefone = "(99) 9 9999-9999",
                    Email = "email@gmail.com",
                    Senha = "12345678",
                    Tipo = "Aluno",
                    Status_Sistema = true,
                    Matricula_Aluno = "",
                    Codigo_Registro_Professor = "",
                    CEP = "88053505",
                    Cidade = "Floripa",
                    UF = "SC",
                    Logradouro = "Rua do Senai",
                    Numero = "222",
                    Complemento = "Complemento",
                    Bairro = "Bairro",
                    Ponto_Referência = "Teste",
                    Empresa_Id = 1
                }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 2,
                    Nome = "PROFESSOR TESTE",
                    Genero = "Masculino",
                    CPF = "999.999.999-99",
                    Telefone = "(99) 9 9999-9999",
                    Email = "email@gmail.com",
                    Senha = "12345678",
                    Tipo = "Professor",
                    Status_Sistema = true,
                    Matricula_Aluno = "",
                    Codigo_Registro_Professor = "",
                    CEP = "88053505",
                    Cidade = "Floripa",
                    UF = "SC",
                    Logradouro = "Rua do Senai",
                    Numero = "222",
                    Complemento = "Complemento",
                    Bairro = "Bairro",
                    Ponto_Referência = "Teste",
                    Empresa_Id = 1
                }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 3,
                    Nome = "PEDAGOGO TESTE",
                    Genero = "Masculino",
                    CPF = "999.999.999-99",
                    Telefone = "(99) 9 9999-9999",
                    Email = "email@gmail.com",
                    Senha = "12345678",
                    Tipo = "Pedagogo",
                    Status_Sistema = true,
                    Matricula_Aluno = "",
                    Codigo_Registro_Professor = "",
                    CEP = "88053505",
                    Cidade = "Floripa",
                    UF = "SC",
                    Logradouro = "Rua do Senai",
                    Numero = "222",
                    Complemento = "Complemento",
                    Bairro = "Bairro",
                    Ponto_Referência = "Teste",
                    Empresa_Id = 1
                }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 4,
                    Nome = "ADMINISTRADOR TESTE",
                    Genero = "Masculino",
                    CPF = "999.999.999-99",
                    Telefone = "(99) 9 9999-9999",
                    Email = "email@gmail.com",
                    Senha = "12345678",
                    Tipo = "Administrador",
                    Status_Sistema = true,
                    Matricula_Aluno = "",
                    Codigo_Registro_Professor = "",
                    CEP = "88053505",
                    Cidade = "Floripa",
                    UF = "SC",
                    Logradouro = "Rua do Senai",
                    Numero = "222",
                    Complemento = "Complemento",
                    Bairro = "Bairro",
                    Ponto_Referência = "Teste",
                    Empresa_Id = 1
                }
            );

            modelBuilder.Entity<Avaliacao>().HasData(
                new Avaliacao
                {
                    Id = 1,
                    Titulo = "EXERCICIO TESTE",
                    Descricao = "DESCRICAO EXERCICIO TESTE",
                    Materia = "TESTE",
                    Data = "10/10/2023",
                    Professor_Id = 2,
                    Aluno_Id = 1
                }
            );

            modelBuilder.Entity<Atendimento>().HasData(
                new Atendimento
                {
                    Id = 1,
                    Descricao = "DESCRICAO EXERCICIO TESTE",
                    Data = "10/10/2023",
                    Pedagogo_Id = 3,
                    Aluno_Id = 1
                }
            );

            modelBuilder.Entity<Exercicio>().HasData(
               new Exercicio
               {
                   Id = 1,
                   Titulo = "EXERCICIO TESTE",
                   Descricao = "DESCRICAO EXERCICIO TESTE",
                   Materia = "TESTE",
                   Data_Conclusao = "10/10/2023",
                   Professor_Id = 2,
                   Aluno_Id = 1
               }
           );


            modelBuilder.Entity<Usuario>()
                .HasOne(x => x.Empresa)
                .WithMany(y => y.Usuarios);
            // .Metadata
            // .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Avaliacao>()
                .HasOne(x => x.Professor)
                .WithMany(y => y.Avaliacoes_Professores)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Avaliacao>()
                .HasOne(x => x.Aluno)
                .WithMany(y => y.Avaliacoes_Alunos)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Cascade;

            modelBuilder.Entity<Exercicio>()
                .HasOne(x => x.Aluno)
                .WithMany(y => y.Exercicios_Alunos)
                .HasForeignKey(x => x.Aluno_Id)
                .Metadata
                .DeleteBehavior = DeleteBehavior.NoAction;

            modelBuilder.Entity<Exercicio>()
                .HasOne(x => x.Professor)
                .WithMany(y => y.Exercicios_Professores)
                .HasForeignKey(x => x.Professor_Id)
                .Metadata
                .DeleteBehavior = DeleteBehavior.NoAction;

            modelBuilder.Entity<Atendimento>()
                .HasOne(x => x.Aluno)
                .WithMany(y => y.Atendimentos_Alunos)
                .HasForeignKey(x => x.Aluno_Id)
                .Metadata
                .DeleteBehavior = DeleteBehavior.NoAction;

            modelBuilder.Entity<Atendimento>()
                .HasOne(x => x.Pedagogo)
                .WithMany(y => y.Atendimentos_Pedagogos)
                .HasForeignKey(x => x.Pedagogo_Id)
                .Metadata
                .DeleteBehavior = DeleteBehavior.NoAction;

            modelBuilder.Entity<Log>()
                .HasOne(x => x.Usuario)
                .WithMany(y => y.Logs);
            // .Metadata
            // .DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}

