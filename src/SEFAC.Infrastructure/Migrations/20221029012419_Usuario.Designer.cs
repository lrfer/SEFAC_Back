﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEFAC.Infrastructure.Persistence;

#nullable disable

namespace SEFAC.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221029012419_Usuario")]
    partial class Usuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SEFAC.Domain.Entities.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CodigoCurso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Cod_Curso");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.Property<string>("NumeroMatriula")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Nr_Matricula");

                    b.HasKey("Id");

                    b.HasIndex("NumeroMatriula")
                        .IsUnique();

                    b.ToTable("Aluno", (string)null);
                });

            modelBuilder.Entity("SEFAC.Domain.Entities.ExecucoesAtividades", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CargaHoraria")
                        .HasColumnType("datetime2")
                        .HasColumnName("Carga_Horaria");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2")
                        .HasColumnName("Dt_Fim");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2")
                        .HasColumnName("Dt_Inicio");

                    b.Property<DateTime>("Duracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("Duracao");

                    b.Property<int>("IdAluno")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdAluno");

                    b.ToTable("Atividade", (string)null);
                });

            modelBuilder.Entity("SEFAC.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Senha");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("SEFAC.Domain.Entities.ExecucoesAtividades", b =>
                {
                    b.HasOne("SEFAC.Domain.Entities.Aluno", "Aluno")
                        .WithMany("ExecucoesAtividades")
                        .HasForeignKey("IdAluno")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("SEFAC.Domain.Entities.Aluno", b =>
                {
                    b.Navigation("ExecucoesAtividades");
                });
#pragma warning restore 612, 618
        }
    }
}
