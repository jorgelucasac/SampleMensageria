using Estudos.Hotelaria.Application.Entities;
using Estudos.Hotelaria.Application.Repositories;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Estudos.Hotelaria.Infrastructure.MongoDb.Repositories
{
    internal class HotelRepository : Repository<Hotel>, IHotelRepository
    {
        public HotelRepository(IMongoDatabase db, ILogger<Repository<Hotel>> log) : base(db, log)
        {
        }
    }
}
