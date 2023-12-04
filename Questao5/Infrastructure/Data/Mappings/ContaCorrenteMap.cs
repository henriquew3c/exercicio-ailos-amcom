using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Data.Mappings
{
    public class ContaCorrenteMap : Mapping<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            base.Configure(builder);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("idcontacorrente");

            builder.Property(c => c.Numero)
                .IsRequired()
                .HasColumnName("numero")
                .HasColumnType("int");

            builder.Property(c => c.Nome)
               .IsRequired()
               .HasColumnName("nome")
               .HasColumnType("varchar(250)");

            builder.Property(c => c.Ativo)
                .IsRequired()
                .HasColumnName("ativo")
                .HasColumnType("int");

            builder.ToTable("contacorrente");
        }
    }
}
