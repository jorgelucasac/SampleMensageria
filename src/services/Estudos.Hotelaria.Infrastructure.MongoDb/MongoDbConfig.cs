using Estudos.Hotelaria.Application.Entities;
using Estudos.Hotelaria.Application.Repositories;
using Estudos.Hotelaria.Infrastructure.MongoDb.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Estudos.Hotelaria.Infrastructure.MongoDb
{
    public static class MongoDbConfig
    {

        public static void UseMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
            if (settings == null)
                throw new ArgumentNullException("Erro ao se conecta ao banco");

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.Database);

            CreateIndexes(database);

            services.AddSingleton(settings);
            services.AddSingleton(client);
            services.AddSingleton(database);
            services.AddTransient<IHotelRepository, HotelRepository>();
        }

        private static void CreateIndexes(IMongoDatabase database)
        {
            var hotel = database.GetCollection<Hotel>(nameof(Hotel));
            hotel.Indexes.CreateMany(new List<CreateIndexModel<Hotel>> {
                new CreateIndexModel<Hotel>(Builders<Hotel>.IndexKeys.Ascending(x => x.Id))
            });
        }
    }
}
