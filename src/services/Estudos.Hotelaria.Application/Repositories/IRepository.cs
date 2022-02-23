using Estudos.Hotelaria.Application.Entities;

namespace Estudos.Hotelaria.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IList<T>> Get();

        Task<T> GetById(Guid id);

        Task Save(T entity);

        Task Delete(Guid id);
    }
}
