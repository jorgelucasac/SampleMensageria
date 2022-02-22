using Estudos.Viagem.Application.Entities;

namespace Estudos.Viagem.Application.Repositories
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