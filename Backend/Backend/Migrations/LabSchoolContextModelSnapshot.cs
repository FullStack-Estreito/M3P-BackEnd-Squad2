﻿// <auto-generated />
using System;
using Backend.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(LabSchoolContext))]
    partial class LabSchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("Backend.Models.Atendimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Aluno_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<int>("Pedagogo_Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Aluno_Id");

                    b.HasIndex("Pedagogo_Id");

                    b.ToTable("Atendimentos");
                });

            modelBuilder.Entity("Backend.Models.Avaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Materia")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("VARCHAR");

                    b.Property<double>("Nota")
                        .HasColumnType("REAL");

                    b.Property<double>("Pontuacao_Maxima")
                        .HasColumnType("REAL");

                    b.Property<int>("Professor_Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Professor_Id");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("Backend.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Demais_Infos")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Logotipo_URL")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Nome_Empresa")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Paleta_Cores")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Slogan")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("Backend.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Ponto_Referencia")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Backend.Models.Exercicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Aluno_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Data_Conclusao")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Materia")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("Professor_Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Aluno_Id");

                    b.HasIndex("Professor_Id");

                    b.ToTable("Exercicios");
                });

            modelBuilder.Entity("Backend.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Acao")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<string>("Detalhes")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<int>("Usuario_Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Usuario_Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Backend.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Codigo_Registro_Professor")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<int>("Empresa_Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Endereco_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Matricula_Aluno")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<bool>("Status_Sistema")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("Empresa_Id");

                    b.HasIndex("Endereco_Id")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Backend.Models.Atendimento", b =>
                {
                    b.HasOne("Backend.Models.Usuario", "Aluno")
                        .WithMany("Atendimentos_Alunos")
                        .HasForeignKey("Aluno_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Backend.Models.Usuario", "Pedagogo")
                        .WithMany("Atendimentos_Pedagogos")
                        .HasForeignKey("Pedagogo_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Pedagogo");
                });

            modelBuilder.Entity("Backend.Models.Avaliacao", b =>
                {
                    b.HasOne("Backend.Models.Usuario", "Professor")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("Professor_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Backend.Models.Exercicio", b =>
                {
                    b.HasOne("Backend.Models.Usuario", "Aluno")
                        .WithMany("Exercicios_Alunos")
                        .HasForeignKey("Aluno_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Backend.Models.Usuario", "Professor")
                        .WithMany("Exercicios_Professores")
                        .HasForeignKey("Professor_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Backend.Models.Log", b =>
                {
                    b.HasOne("Backend.Models.Usuario", "Usuario")
                        .WithMany("Logs")
                        .HasForeignKey("Usuario_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Backend.Models.Usuario", b =>
                {
                    b.HasOne("Backend.Models.Empresa", "Empresa")
                        .WithMany("Usuarios")
                        .HasForeignKey("Empresa_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Backend.Models.Endereco", "Endereco")
                        .WithOne("Usuario")
                        .HasForeignKey("Backend.Models.Usuario", "Endereco_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Backend.Models.Empresa", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Backend.Models.Endereco", b =>
                {
                    b.Navigation("Usuario")
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Models.Usuario", b =>
                {
                    b.Navigation("Atendimentos_Alunos");

                    b.Navigation("Atendimentos_Pedagogos");

                    b.Navigation("Avaliacoes");

                    b.Navigation("Exercicios_Alunos");

                    b.Navigation("Exercicios_Professores");

                    b.Navigation("Logs");
                });
#pragma warning restore 612, 618
        }
    }
}
