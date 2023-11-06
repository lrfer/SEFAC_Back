using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEFAC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEFAC.Infrastructure.Persistence.Configurations
{
    public class AtividadeConfiguration : IEntityTypeConfiguration<Domain.Entities.Atividade>
    {
        public void Configure(EntityTypeBuilder<Atividade> builder)
        {
            builder.ToTable("Atividade");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .IsRequired();

            builder.Property(x=> x.CodigoSiex)
                .HasColumnName("Cd_siex")
                .IsRequired();

            builder.Property(x => x.Base64PDF)
                .HasColumnName("Anexo");



            builder.HasMany(x => x.Execucoes)
                    .WithOne(x => x.Atividade)
                    .HasForeignKey(x => x.IdAtividade)
                    .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
