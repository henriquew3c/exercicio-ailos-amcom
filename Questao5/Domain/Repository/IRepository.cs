namespace Questao5.Domain.Repository
{

    public interface IRepository<T>
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
