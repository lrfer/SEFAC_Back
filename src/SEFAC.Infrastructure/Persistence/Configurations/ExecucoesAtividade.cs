using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SEFAC.Infrastructure.Persistence.Configurations
{
    public class ExecucoesAtividade : IEntityTypeConfiguration<Domain.Entities.ExecucoesAtividades>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.ExecucoesAtividades> builder)
        {
            builder.ToTable("Atividade").HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Nome).IsRequired();

            builder.Property(x => x.Duracao)
                .HasColumnName("Duracao")
                .IsRequired();

            builder.Property(x => x.CargaHoraria)
                .HasColumnName("Carga_Horaria")
                .IsRequired();

            builder.Property(x => x.DataFim)
                .HasColumnName("Dt_Fim")
                .IsRequired();

            builder.Property(x => x.DataInicio)
                .HasColumnName("Dt_Inicio")
                .IsRequired();

            builder.Property(x => x.Duracao)
                .HasColumnName("Duracao")
                .IsRequired();


            builder.HasOne(x => x.Aluno)
                    .WithMany(x => x.ExecucoesAtividades)
                    .HasForeignKey(x => x.IdAluno)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
