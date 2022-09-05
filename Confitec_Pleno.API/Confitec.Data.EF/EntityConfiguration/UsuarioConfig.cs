using Confitec.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Data.EF.EntityConfiguration
{
    internal class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIOS");

            builder.Property(p => p.Id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Nome).HasMaxLength(80);
            builder.Property(p => p.Sobrenome).HasMaxLength(80);
            builder.Property(p => p.Email).HasMaxLength(80);
            builder.Property(p => p.DataNascimento).HasColumnType("datetime");
            builder.Property(p => p.Escolaridade).HasColumnType("int");

        }
    }
}
