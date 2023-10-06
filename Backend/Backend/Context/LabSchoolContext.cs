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

        // Tabelas
        public DbSet<AtendimentoModel> Atendimentos { get; set; }
        public DbSet<EmpresaModel> Empresas { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<ExercicioModel> Exercicios { get; set; }
        public DbSet<LogModel> Logs { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        // Declaração dos relacionamentos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>()
                .HasOne(x => x.Endereco)
                .WithOne(y => y.Usuario)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<UsuarioModel>()
                .HasOne(x => x.Empresa)
                .WithMany(y => y.Usuarios)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<LogModel>()
                .HasOne(x => x.Usuario)
                .WithMany(y => y.Logs)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<AvaliacaoModel>()
                .HasOne(x => x.Professor)
                .WithMany(y => y.Avaliacoes)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<ExercicioModel>()
                .HasOne(x => x.Usuario)
                .WithMany(y => y.Exercicios)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<AtendimentoModel>()
                .HasOne(x => x.Usuario)
                .WithMany(y => y.Atendimentos)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}

