using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEFAC.Domain.Entities;

namespace SEFAC.Infrastructure.Persistence.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Domain.Entities.Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .IsRequired();

            builder.Property(x => x.Senha)
                .HasColumnName("Senha")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .IsRequired();

        }
    }
}
