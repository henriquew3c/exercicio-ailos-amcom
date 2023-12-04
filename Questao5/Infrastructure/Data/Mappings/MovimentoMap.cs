using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Data.Mappings
{
    public class MovimentoMap : Mapping<Movimento>
    {
        public void Configure(EntityTypeBuilder<Movimento> builder)
        {
            base.Configure(builder);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("idmovimento");

            builder.Property(c => c.ContaCorrenteId)
                .IsRequired()
                .HasColumnName("idcontacorrente")
                .HasColumnType("varchar(10)");

            builder.Property(c => c.DataMovimento)
               .IsRequired()
               .HasColumnName("datamovimento")
               .HasColumnType("datetime");

            builder.Property(c => c.TipoMovimento)
                .IsRequired()
                .HasColumnName("tipomovimento")
                .HasColumnType("int");

            builder.Property(c => c.Valor)
               .IsRequired()
               .HasColumnName("valor")
               .HasColumnType("double");

            builder.ToTable("movimento");
        }
    }
}
