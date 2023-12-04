using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Data.Mappings
{
    public abstract class Mapping<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Ignore(x => x.IsInvalid);
            builder.Ignore(x => x.IsValid);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
