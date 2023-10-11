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

        // 
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Empresa>().HasData(
            //     new Empresa
            //     {
            //         Id = 1,
            //         Nome_Empresa = "S",
            //         Slogan = "a",
            //         Paleta_Cores = "B",
            //         Logotipo_URL = "w",
            //         Demais_Infos = "U"
            //     }
            // );

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
                .HasOne(x => x.Aluno)
                .WithMany(y => y.Exercicios_Alunos)
                .HasForeignKey( x => x.Aluno_Id)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Exercicio>()
                .HasOne(x => x.Professor)
                .WithMany(y => y.Exercicios_Professores)
                .HasForeignKey( x => x.Professor_Id)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Atendimento>()
                .HasOne(x => x.Aluno)
                .WithMany(y => y.Atendimentos_Alunos)
                .HasForeignKey( x => x.Aluno_Id)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Atendimento>()
                .HasOne(x => x.Pedagogo)
                .WithMany(y => y.Atendimentos_Pedagogos)
                .HasForeignKey( x => x.Pedagogo_Id)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Log>()
                .HasOne(x => x.Usuario)
                .WithMany(y => y.Logs)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Login>();

            base.OnModelCreating(modelBuilder);
        }
    }
}

