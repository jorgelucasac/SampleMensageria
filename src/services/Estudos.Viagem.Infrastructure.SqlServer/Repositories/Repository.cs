using Estudos.Viagem.Application.Entities;
using Estudos.Viagem.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Estudos.Viagem.Infrastructure.SqlServer.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ViagemDataContext _context;

        public Repository(ViagemDataContext context)
        {
            _context = context;
        }

        public async Task<IList<T>> GetAll()
        {
            try
            {
                return await _context.Set<T>().AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Fail to list the entites", ex);
            }
        }

        public async Task<T?> GetById(Guid id)
        {
            try
            {
                return await _context.Set<T>()
                    .AsNoTracking()
                    .SingleOrDefaultAsync(e => e.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception("Fail to get the entity by Id", ex);
            }
        }

        public async Task Save(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Fail to save the entity", ex);
            }
        }

        public async Task Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Fail to update the entity", ex);
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var entity = await GetById(id);
                if (entity == null) return;

                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Fail to delete the entity", ex);
            }
        }
    }
}
