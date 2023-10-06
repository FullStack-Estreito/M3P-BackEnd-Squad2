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
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        // Declaração dos relacionamentos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasOne(x => x.Endereco)
                .WithOne(y => y.Usuario)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Usuario>()
                .HasOne(x => x.Empresa)
                .WithMany(y => y.Usuarios)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Avaliacao>()
                .HasOne(x => x.Professor)
                .WithMany(y => y.Avaliacoes)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Exercicio>()
                .HasOne(x => x.Usuario)
                .WithMany(y => y.Exercicios)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Atendimento>()
                .HasOne(x => x.Usuario)
                .WithMany(y => y.Atendimentos)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Log>()
                .HasOne(x => x.Usuario)
                .WithMany(y => y.Logs)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}

