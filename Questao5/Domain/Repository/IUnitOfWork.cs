namespace Questao5.Domain.Repository
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
