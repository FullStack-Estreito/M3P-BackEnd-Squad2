using System;
using Backend.Base;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{
    public class LabSchoolContext : DbContext
    {
        public LabSchoolContext(DbContextOptions options) : base(options)
        {
        }

        // Tabelas
        public DbSet<AdministradorModel> Administradores { get; set; }
        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<AtendimentoModel> Atendimentos { get; set; }
        public DbSet<BaseUsuarioModel> Usuarios { get; set; }
        public DbSet<EmpresaModel> Empresas { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<ExercicioModel> Exercicios { get; set; }
        public DbSet<LogModel> Logs { get; set; }
        public DbSet<PedagogoModel> Pedagogos { get; set; }
        public DbSet<ProfessorModel> Professores { get; set; }

        // Declaração dos relacionamentos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdministradorModel>()
                .HasOne(x => x.Empresa)
                .WithOne(y => y.Administrador)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict; 

            modelBuilder.Entity<AtendimentoModel>()
                .HasOne(x => x.Aluno)
                .WithMany(y => y.Atendimentos)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<AtendimentoModel>()
                .HasOne(x => x.Pedagogo)
                .WithMany(y => y.Atendimentos)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<BaseUsuarioModel>()
                .HasOne(x => x.Endereco)
                .WithOne(y => y.Usuario)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<ExercicioModel>()
                .HasOne(x => x.Aluno)
                .WithMany(y => y.Exercicios)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<ExercicioModel>()
                .HasOne(x => x.Professor)
                .WithMany(y => y.Exercicios)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<LogModel>()
                .HasOne(x => x.Usuario)
                .WithMany(y => y.Logs)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}

