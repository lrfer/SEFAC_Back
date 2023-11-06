using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEFAC.Domain.Entities;

namespace SEFAC.Infrastructure.Persistence.Configurations
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno").HasKey(x => x.Id);

            builder.HasIndex(x => x.NumeroMatricula).IsUnique();

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CodigoCurso)
                .HasColumnName("Cod_Curso")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .IsRequired();

            builder.Property(x => x.NumeroMatricula)
                .HasColumnName("Nr_Matricula")
                .IsRequired();

            builder.HasMany(x => x.ExecucaoAtividades)
                    .WithOne(x => x.Aluno)
                    .HasForeignKey(x => x.IdAluno)
                    .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
