using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Data.Mappings
{

    public class IndepotenciaMap : Mapping<Indepotencia>
    {
        public void Configure(EntityTypeBuilder<Indepotencia> builder)
        {
            base.Configure(builder);

            builder.Ignore(c => c.Id);

            builder.Property(c => c.Chave)
                .IsRequired()
                .HasColumnName("chave_idempotencia")
                .HasColumnType("varchar(37)");

            builder.Property(c => c.Requisicao)
               .IsRequired()
               .HasColumnName("requisicao")
               .HasColumnType("varchar(1000)");

            builder.Property(c => c.Resultado)
                .IsRequired()
                .HasColumnName("resultado")
                .HasColumnType("varchar(1000)");

            builder.ToTable("idempotencia");
        }
    }
}
