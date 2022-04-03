using Estudos.Viagem.Domain.Entities;

namespace Estudos.Viagem.Domain.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IList<T>> GetAll();
        Task<T?> GetById(Guid id);
        Task Save(T entity);
        Task Update(T entity);
        Task Delete(Guid id);
    }
}