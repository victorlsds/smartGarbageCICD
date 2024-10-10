using Microsoft.EntityFrameworkCore;
using vstudy.smartgarbage.Model;

namespace vstudy.smartgarbage.Data.Context
{
    public class DatabaseContext : DbContext
    {

        public virtual DbSet<AgendamentoColetaModel> AgendamentoColeta { get; set; }
        public virtual DbSet<ResiduoColetaModel> ResiduoColeta { get; set; }
        public virtual DbSet<PontosColetaModel> PontoColeta { get; set; }
        public virtual DbSet<FeedbackModel> Feedback { get; set; }
        public virtual DbSet<UsuarioModel> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgendamentoColetaModel>(entity =>
            {
                entity.ToTable("TBL_SG_AGENDACOLETA");
                entity.HasKey(e => e.AgendamentoId);

                //regras de negócio
                entity.Property(e => e.UsuarioId).IsRequired();
                //entity.Property(e => e.ResiduoColetaId).IsRequired();
                entity.Property(e => e.PontoColetaId).IsRequired();
                entity.Property(e => e.DataAgendamento).IsRequired();
                entity.Property(e => e.Status).IsRequired();

                entity.Property(e => e.Status).HasMaxLength(1000);

                entity.Property(e => e.DataAgendamento).HasColumnType("date");

                //relacionamentos entre classes
                entity.HasOne(e => e.Usuario).WithMany()
                .HasForeignKey(e => e.UsuarioId).IsRequired();

                entity.HasOne(e => e.PontoColeta).WithMany()
                .HasForeignKey(e => e.PontoColetaId).IsRequired();
            });

            modelBuilder.Entity<ResiduoColetaModel>(entity =>
            {
                entity.ToTable("TBL_SG_RESIDUOCOLETA");
                entity.HasKey(e => e.ResiduoColetaId);

                //regras de negócio
                entity.Property(e => e.TipoResiduo).IsRequired();
                //entity.Property(e => e.PontoColetaId).IsRequired();

                entity.Property(e => e.TipoResiduo).HasMaxLength(100);

                //relacionamentos entre classes
                //entity.HasOne(e => e.PontoColeta).WithMany()
                //.HasForeignKey(e => e.PontoColetaId).IsRequired();
                entity.HasOne(f => f.AgendamentoColeta).WithMany()
                .HasForeignKey(f => f.AgendamentoColetaId);
            });

            modelBuilder.Entity<PontosColetaModel>(entity =>
            {
                entity.ToTable("TBL_SG_PONTOSCOLETA");
                entity.HasKey(e => e.PontoId);

                //regras de negócio
                entity.Property(e => e.TipoLogradouro).IsRequired();
                entity.Property(e => e.Logradouro).IsRequired();
                entity.Property(e => e.Numero).IsRequired();
                entity.Property(e => e.CEP).IsRequired();

                entity.Property(e => e.Logradouro).HasMaxLength(100);
                entity.Property(e => e.Numero).HasMaxLength(5);
                entity.Property(e => e.CEP).HasMaxLength(8);
            });

            modelBuilder.Entity<FeedbackModel>(entity =>
            {
                entity.ToTable("TBL_SG_FEEDBACK");
                entity.HasKey(e => e.FeedBackId);

                //regras de negócio
                entity.Property(e => e.UsuarioId).IsRequired();
                entity.Property(e => e.AgendamentoColetaId).IsRequired();
                entity.Property(e => e.Mensagem).IsRequired();
                entity.Property(e => e.DataFeedback).IsRequired();

                entity.Property(e => e.Mensagem).HasMaxLength(500);

                entity.Property(e => e.DataFeedback).HasColumnType("date");

                //relacionamentos entre classes
                entity.HasOne(e => e.Usuario).WithMany()
                .HasForeignKey(e => e.UsuarioId).IsRequired();

                entity.HasOne(e => e.AgendamentoColetaLixo).WithMany()
                .HasForeignKey(e => e.AgendamentoColetaId).IsRequired();
            });

            modelBuilder.Entity<UsuarioModel>(entity =>
            {
                entity.ToTable("TBL_SG_USUARIO");
                entity.HasKey(e => e.UsuarioId);

                //regras de negócio
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Senha).IsRequired();
                entity.Property(e => e.Role).IsRequired();
            });
        }

        public DatabaseContext(DbContextOptions options) : base(options) { }
        protected DatabaseContext() { }
    }
}
