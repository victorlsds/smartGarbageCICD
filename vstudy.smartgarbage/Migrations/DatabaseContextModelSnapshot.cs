﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using vstudy.smartgarbage.Data.Context;

#nullable disable

namespace vstudy.smartgarbage.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("vstudy.smartgarbage.Model.AgendamentoColetaModel", b =>
                {
                    b.Property<int>("AgendamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgendamentoId"));

                    b.Property<DateTime>("DataAgendamento")
                        .HasColumnType("date");

                    b.Property<int>("PontoColetaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("NVARCHAR2(1000)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("AgendamentoId");

                    b.HasIndex("PontoColetaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TBL_SG_AGENDACOLETA", (string)null);
                });

            modelBuilder.Entity("vstudy.smartgarbage.Model.FeedbackModel", b =>
                {
                    b.Property<int>("FeedBackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedBackId"));

                    b.Property<int>("AgendamentoColetaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("DataFeedback")
                        .HasColumnType("date");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR2(500)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("FeedBackId");

                    b.HasIndex("AgendamentoColetaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TBL_SG_FEEDBACK", (string)null);
                });

            modelBuilder.Entity("vstudy.smartgarbage.Model.PontosColetaModel", b =>
                {
                    b.Property<int>("PontoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PontoId"));

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("NVARCHAR2(8)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<int>("Numero")
                        .HasMaxLength(5)
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("TipoLogradouro")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("PontoId");

                    b.ToTable("TBL_SG_PONTOSCOLETA", (string)null);
                });

            modelBuilder.Entity("vstudy.smartgarbage.Model.ResiduoColetaModel", b =>
                {
                    b.Property<int>("ResiduoColetaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResiduoColetaId"));

                    b.Property<int>("AgendamentoColetaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("TipoResiduo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.HasKey("ResiduoColetaId");

                    b.HasIndex("AgendamentoColetaId");

                    b.ToTable("TBL_SG_RESIDUOCOLETA", (string)null);
                });

            modelBuilder.Entity("vstudy.smartgarbage.Model.UsuarioModel", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("UsuarioId");

                    b.ToTable("TBL_SG_USUARIO", (string)null);
                });

            modelBuilder.Entity("vstudy.smartgarbage.Model.AgendamentoColetaModel", b =>
                {
                    b.HasOne("vstudy.smartgarbage.Model.PontosColetaModel", "PontoColeta")
                        .WithMany()
                        .HasForeignKey("PontoColetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vstudy.smartgarbage.Model.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PontoColeta");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("vstudy.smartgarbage.Model.FeedbackModel", b =>
                {
                    b.HasOne("vstudy.smartgarbage.Model.AgendamentoColetaModel", "AgendamentoColetaLixo")
                        .WithMany()
                        .HasForeignKey("AgendamentoColetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vstudy.smartgarbage.Model.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgendamentoColetaLixo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("vstudy.smartgarbage.Model.ResiduoColetaModel", b =>
                {
                    b.HasOne("vstudy.smartgarbage.Model.AgendamentoColetaModel", "AgendamentoColeta")
                        .WithMany()
                        .HasForeignKey("AgendamentoColetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgendamentoColeta");
                });
#pragma warning restore 612, 618
        }
    }
}