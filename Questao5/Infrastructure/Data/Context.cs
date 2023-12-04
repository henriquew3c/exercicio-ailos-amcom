using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Questao5.Domain.Entities;
using Questao5.Domain.Repository;
using Questao5.Infrastructure.Data.Mappings;

namespace Questao5.Infrastructure.Data
{
    public class Context : DbContext, IUnitOfWork
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Indepotencia>().HasNoKey();

            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<ValidationFailure>();

            modelBuilder.ApplyConfiguration(new MovimentoMap());
            modelBuilder.ApplyConfiguration(new ContaCorrenteMap());
            modelBuilder.ApplyConfiguration(new IndepotenciaMap());

            modelBuilder.Entity<ContaCorrente>()
            .Property(e => e.Id).HasColumnName("idcontacorrente");

            modelBuilder.Entity<Movimento>()
            .Property(e => e.Id).HasColumnName("idmovimento");

            modelBuilder.Entity<Movimento>()
            .Property(e => e.ContaCorrenteId).HasColumnName("idcontacorrente");


            modelBuilder.Entity<Movimento>()
            .Property(e => e.TipoMovimento).HasColumnName("tipomovimento");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<ContaCorrente> ContaCorrente { get; set; }

        public DbSet<Movimento> Movimento { get; set; }

        public DbSet<Indepotencia> Indepotencia { get; set; }

        public async Task<bool> CommitAsync()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
