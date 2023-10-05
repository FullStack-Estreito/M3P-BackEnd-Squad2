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

        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Pedagogo> Pedagogos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        // Declaração dos relacionamentos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Atendimento>()
                .HasOne(x => x.Aluno)
                .WithMany(y => y.Atendimentos)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Atendimento>()
                .HasOne(x => x.Pedagogo)
                .WithMany(y => y.Atendimentos)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;


            modelBuilder.Entity<Exercicio>()
                .HasOne(x => x.Aluno)
                .WithMany(y => y.Exercicios)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Exercicio>()
                .HasOne(x => x.Professor)
                .WithMany(y => y.Exercicios)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            // modelBuilder.Entity<Log>()
            //     .HasOne(x => x.Admin)
            //     .WithMany(y => y.Logs)
            //     .Metadata
            //     .DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}

