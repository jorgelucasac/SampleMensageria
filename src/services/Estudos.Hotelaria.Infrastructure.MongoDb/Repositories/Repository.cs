using Estudos.Hotelaria.Application.Entities;
using Estudos.Hotelaria.Application.Repositories;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Estudos.Hotelaria.Infrastructure.MongoDb.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ILogger<Repository<T>> _log;
        private readonly IMongoCollection<T> _collection;

        public Repository(IMongoDatabase db, ILogger<Repository<T>> log)
        {
            _collection = db.GetCollection<T>(typeof(T).Name);
            _log = log;
        }

        public async Task<IList<T>> Get()
        {
            try
            {
                return await _collection.Find(x => true).ToListAsync();
            }
            catch (Exception e)
            {
                const string erroMsg = "Ocorreu um erro ao listar os registros";
                _log.LogError(erroMsg, e);
                throw new Exception(erroMsg, e);
            }
        }

        public async Task<T> GetById(Guid id)
        {
            try
            {
                return await _collection.Find(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                const string erroMsg = "Ocorreu um erro ao listar o registro";
                _log.LogError(erroMsg, e);
                throw new Exception(erroMsg, e);
            }
        }

        public async Task Save(T entity)
        {
            try
            {
                await _collection.ReplaceOneAsync(x => x.Id.Equals(entity.Id), entity, new ReplaceOptions { IsUpsert = true });
            }
            catch (Exception e)
            {
                const string erroMsg = "Ocorreu um erro ao salvaar i registro";
                _log.LogError(erroMsg, e);
                throw new Exception(erroMsg, e);
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                await _collection.DeleteOneAsync(x => x.Id.Equals(id));
            }
            catch (Exception e)
            {
                const string erroMsg = "Ocorreu um erro ao deletar o registro";
                _log.LogError(erroMsg, e);
                throw new Exception(erroMsg, e);
            }
        }
    }
}
